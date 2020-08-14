using Microsoft.Extensions.Logging;
using Pandora.NetStandard.Business.Mappers;
using Pandora.NetStandard.Business.Services.Contracts;
using Pandora.NetStandard.Business.States;
using Pandora.NetStdLibrary.Base.Base;
using Pandora.NetStdLibrary.Base.Interfaces;
using Pandora.NetStdLibrary.Base.Mapper;
using Pandora.NetStdLibrary.Base.Utils;
using Pandora.NetStandard.Model.Dtos;
using Pandora.NetStandard.Model.Entities;
using Pandora.NetStandard.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pandora.NetStandard.Business.Services
{
    public class SubjectSvc : BaseService<Subject, SubjectDto>, ISubjectSvc
    {
        private readonly IStudentStateSvc _studentStateSvc;
        private readonly IMapperCore _mapperExplicit;
        public SubjectSvc(IIdentityAppUow applicationUow, ILogger<SubjectSvc> logger,
            IStudentStateSvc studentStateSvc)
            : base(applicationUow, logger, new SubjectToDtoMapper())
        {
            _studentStateSvc = studentStateSvc;
            _mapperExplicit = new GenericMapper();
        }

        public async Task<BLSingleResponse<SubjectDto>> CreateAsync(SubjectDto pDto)
        {
            var response = new BLSingleResponse<SubjectDto>();

            try
            {
                var entityResult = await _uow.GetRepository<Subject>().InsertAsync(pDto);
                if (await _uow.CommitAsync())
                {
                    response.Data = _mapper.MapEntity(entityResult);
                }
                else
                {
                    HandleSVCException(response, "This action couldn't be performed.");
                }
            }
            catch (Exception ex)
            {
                HandleSVCException(response, ex);
            }

            return response;
        }

        public async Task<BLSingleResponse<bool>> DeleteAsync(SubjectDto pDto)
        {
            throw new NotImplementedException();
        }

        public async Task<BLListResponse<SubjectDto>> GetAllAsync()
        {
            var response = new BLListResponse<SubjectDto>();

            try
            {
                var entitiesResult = await _uow.GetRepository<Subject>().AllAsync(null, null, null);
                response.Data = _mapper.MapEntity(entitiesResult);

            }
            catch (Exception ex)
            {
                HandleSVCException(response, ex);
            }

            return response;
        }

        public async Task<BLSingleResponse<bool>> SaveSubjectExams(SubjectDto pSubject)
        {
            var response = new BLSingleResponse<bool>();

            try
            {
                await _uow.GetRepository<Subject>().UpdateAsync(pSubject);
                if (await _uow.CommitAsync())
                {
                    response.Data = true;
                }
                else
                {
                    HandleSVCException(response, "This action couldn't be performed.");
                }
            }
            catch (Exception ex)
            {
                HandleSVCException(response, ex);
            }

            return response;
        }

        public async Task<BLSingleResponse<SubjectDto>> GetByIdAsync(int pId)
        {
            var response = new BLSingleResponse<SubjectDto>();

            try
            {
                var entityResult = await _uow.GetRepository<Subject>().GetByIdAsync(pId);
                response.Data = _mapper.MapEntity(entityResult);
            }
            catch (Exception ex)
            {
                HandleSVCException(response, ex);
            }

            return response;
        }

        public async Task<BLSingleResponse<bool>> UpdateAsync(SubjectDto pDto)
        {
            throw new NotImplementedException();
        }

        public async Task<BLSingleResponse<bool>> EnrollStudentAsync(int subjectId, int userId)
        {
            var response = new BLSingleResponse<bool>();

            try
            {
                //TODO: applay transaction capability
                //using (var trx = await _uow.StartTransactionAsync())
                //{
                //    trx.Commit();
                //}

                var subjEntity = await _uow.GetRepository<Subject>().GetByIdAsync(subjectId);
                if (subjEntity == null)
                    throw new Exception($"Subject Id = {subjectId} didn't match any result.");

                var studentResult = await _uow.GetRepository<Student>().GetByExpressionAsync(s => s.ApplicationUserId == userId);

                StateManager stateManager = await StateManager.GetStateManagerAsync(_studentStateSvc, studentResult.Id, subjectId);
                response.Data = await stateManager.EnrollStudentAsync(
                    _mapperExplicit.MapEntity<Student, StudentDto>(studentResult), _mapperExplicit.MapEntity<Subject, SubjectDto>(subjEntity));

            }
            catch (Exception ex)
            {
                HandleSVCException(response, ex);
            }

            return response;
        }

        public async Task<BLSingleResponse<bool>> SaveExamResultAsync(int subjectId, StudentDto studentDto)
        {
            var response = new BLSingleResponse<bool>();

            try
            {
                foreach (Exam exam in studentDto.Exams)
                {
                    exam.Date = DateTime.Now;

                    var entityExam = await _uow.GetRepository<Exam>()
                        .GetByExpressionAsync(e => e.SubjectId == subjectId && e.StudentId == studentDto.Id && e.ExamType == exam.ExamType);

                    if (entityExam != null)
                    {
                        if (entityExam.Score != exam.Score)
                        {
                            entityExam.Score = exam.Score;
                            entityExam.Date = exam.Date;
                            await _uow.GetRepository<Exam>().UpdateAsync(entityExam);
                        }
                        continue;
                    }

                    exam.SubjectId = subjectId;
                    exam.StudentId = studentDto.Id;
                    await _uow.GetRepository<Exam>().InsertAsync(exam);
                }
                response.Data = await _uow.CommitAsync();
            }
            catch (Exception ex)
            {
                HandleSVCException(response, ex);
            }

            return response;
        }

        public async Task<BLListResponse<SubjectDto>> GetByUserIdAsync<TEntity>(int userId) where TEntity : class
        {
            var response = new BLListResponse<SubjectDto>();

            try
            {
                IEnumerable<Subject> subjResult = new List<Subject>();
                IEntity entitiesResult;

                if (typeof(TEntity).BaseType == typeof(Student))
                {
                    entitiesResult = await _uow.GetRepository<Student>().GetByExpressionAsync(sb => sb.ApplicationUserId == userId);

                    if (entitiesResult != null)
                    {
                        subjResult = await _uow.GetRepository<Subject>().AllAsync(s => s.StudentStates.Any(ss => ss.StudentId == entitiesResult.Id),
                                            null,
                                            x => x.Include(s => s.Attends),
                                            x => x.Include(s => s.Exams));

                        response.Data = _mapper.MapEntity(subjResult);
                    }
                }
                else if (typeof(TEntity).BaseType == typeof(Teacher))
                {
                    entitiesResult = await _uow.GetRepository<Teacher>().GetByExpressionAsync(sb => sb.ApplicationUserId == userId);

                    if (entitiesResult != null)
                    {
                        subjResult = await _uow.GetRepository<Subject>().AllAsync(s => s.SubjectAssingments.Any(sa => sa.TeacherId == entitiesResult.Id),
                                            null,
                                            x => x.Include(s => s.SubjectAssingments).ThenInclude(sa => sa.Class),
                                            x => x.Include(s => s.SubjectAssingments).ThenInclude(sa => sa.ClassRoom));

                        response.Data = _mapper.MapEntity(subjResult);
                    }
                }
                else
                    throw new ArgumentException("Only Student and Teacher has subject assosiated.");
            }
            catch (Exception ex)
            {
                HandleSVCException(response, ex);
            }

            return response;
        }

        public async Task<BLSingleResponse<bool>> TryEnrollAsync(int subjectId, int studentId)
        {
            var response = new BLSingleResponse<bool>() { Data = true };

            try
            {
                var subjResponse = await _uow.GetRepository<Subject>().FindAsync(s => s.Id == subjectId, x => x.Include(s => s.PreReqSubject));
                if (subjResponse == null)
                    throw new Exception($"Subject Id = {subjectId} didn't match any result.");

                //check if he is already enrolled 
                var isAlreadyEnrolled = await _uow.GetRepository<Student>().ExistAsync(s => s.ApplicationUserId == studentId && s.StudentStates
                .Any(ss => ss.SubjectId == subjectId && ss.AcademicState == StudentStateEnum.ENROLLED));

                if (isAlreadyEnrolled)
                {
                    response.Errors.Add("You're already enrolled to this subject.");
                    response.Data = false;
                    return response;
                }

                //check if the subject has a prerequired subject
                if (subjResponse.PreReqSubject != null)
                {
                    var hasNotPreReq = await _uow.GetRepository<Student>()
                        .ExistAsync(s => s.ApplicationUserId == studentId && s.StudentStates
                        .Any(ss => ss.SubjectId == subjResponse.PreReqSubject.Id && ss.AcademicState == StudentStateEnum.ACHIEVED));

                    if (!hasNotPreReq)
                        response.Errors.Add("You cannot enroll to this subject due to previous requirement.");
                    response.Data = hasNotPreReq;
                }
            }
            catch (Exception ex)
            {
                HandleSVCException(response, ex);
            }

            return response;
        }

        public async Task<BLSingleResponse<bool>> SaveAttendsAsync(int subjectId, IList<StudentDto> studentDtos)
        {
            var response = new BLSingleResponse<bool>();

            try
            {
                foreach (StudentDto stud in studentDtos)
                {
                    var attend = new Attend
                    {
                        SubjectId = subjectId,
                        StudentId = stud.Id,
                        Attendance = stud.TodayAttend.Attendance,
                        Obs = stud.TodayAttend.Obs,
                        Date = DateTime.Now
                    };

                    await _uow.GetRepository<Attend>().InsertAsync(attend);
                }
                response.Data = await _uow.CommitAsync();
            }
            catch (Exception ex)
            {
                HandleSVCException(response, ex);
            }

            return response;
        }
    }
}
