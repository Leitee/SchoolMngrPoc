using Microsoft.Extensions.Logging;
using Pandora.NetStandard.Business.Mappers;
using Pandora.NetStandard.Business.Services.Contracts;
using Pandora.NetStandard.Business.States;
using Pandora.NetStandard.Core.Base;
using Pandora.NetStandard.Core.Interfaces;
using Pandora.NetStandard.Core.Mapper;
using Pandora.NetStandard.Core.Utils;
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
        public SubjectSvc(IApplicationUow applicationUow, ILogger<SubjectSvc> logger,
            IStudentStateSvc studentStateSvc)
            : base(applicationUow, logger, new SubjectToDtoMapper())
        {
            _studentStateSvc = studentStateSvc;
            _mapperExplicit = new GenericMapperCore();
        }

        public async Task<BLSingleResponse<SubjectDto>> CreateAsync(SubjectDto pDto)
        {
            var response = new BLSingleResponse<SubjectDto>();

            try
            {
                var entityResult = await _uow.GetRepo<Subject>().InsertAsync(pDto);
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
                var entitiesResult = await _uow.GetRepo<Subject>().AllAsync(null, null, null);
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
                await _uow.GetRepo<Subject>().UpdateAsync(pSubject);
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
                var entityResult = await _uow.GetRepo<Subject>().GetByIdAsync(pId);
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
                var subjResponse = await GetByIdAsync(subjectId);
                if (subjResponse.HasError || subjResponse.Data == null)
                    throw new Exception($"Subject Id = {subjectId} didn't match any result.");

                var studentResult = await _uow.GetRepo<Student>().FindAsync(s => s.ApplicationUserId == userId, x => x.Include(s => s.ApplicationUser));

                StateManager stateManager = await StateManager.GetStateManagerAsync(_studentStateSvc, studentResult.Id, subjectId);
                response.Data = await stateManager.EnrollStudentAsync(_mapperExplicit.MapEntity<Student, StudentDto>(studentResult), subjResponse.Data);
            }
            catch (Exception ex)
            {
                HandleSVCException(response, ex);
            }

            return response;
        }

        public async Task<BLSingleResponse<bool>> SaveExamResultAsync(IList<ExamDto> examDtos)
        {
            var response = new BLSingleResponse<bool>();

            try
            {
                foreach (ExamDto exam in examDtos)
                {
                    await _uow.GetRepo<Exam>().InsertAsync(exam);
                }

                if(await _uow.CommitAsync())
                {
                    StateManager stateManager = await StateManager.GetStateManagerAsync(_studentStateSvc, examDtos.FirstOrDefault().StudentId, examDtos.FirstOrDefault().SubjectId);
                    response.Data = await stateManager.SaveExamsResultAsync(examDtos);
                }
                else
                {
                    response.Data = false;
                }
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
                IEntity entitiesResult;
                IEnumerable<Subject> subjResult = new List<Subject>();
                if (typeof(TEntity).BaseType == typeof(Student))
                {
                    entitiesResult = await _uow.GetRepo<Student>().FindAsync(sb => sb.ApplicationUserId == userId);
                    subjResult = await _uow.GetRepo<Subject>().AllAsync(s => s.StudentStates.Any(ss => ss.StudentId == entitiesResult.Id),
                        null,
                        x => x.Include(s => s.Attends),
                        x => x.Include(s => s.Exams));
                }
                else if (typeof(TEntity).BaseType == typeof(Teacher))
                {
                    entitiesResult = await _uow.GetRepo<Teacher>().FindAsync(sb => sb.ApplicationUserId == userId);
                    subjResult = await _uow.GetRepo<Subject>().AllAsync(s => s.StudentStates.Any(ss => ss.StudentId == entitiesResult.Id),
                        null,
                        x => x.Include(s => s.Attends),
                        x => x.Include(s => s.Exams));
                }
                else
                    throw new ArgumentException("Only Student and Teacher has subject assosiated.");

                response.Data = _mapper.MapEntity(subjResult);
            }
            catch (Exception ex)
            {
                HandleSVCException(response, ex);
            }

            return response;
        }

        public async Task<BLSingleResponse<bool>> TryEnrollAsync(int subjectId, int studentId)
        {
            var response = new BLSingleResponse<bool>() { Data = true};

            try
            {
                var subjResponse = await _uow.GetRepo<Subject>().FindAsync(s => s.Id == subjectId, x => x.Include(s => s.PreReqSubject));
                if (subjResponse == null)
                    throw new Exception($"Subject Id = {subjectId} didn't match any result.");

                if (subjResponse.PreReqSubject != null)
                {
                    response.Data = await _uow.GetRepo<Student>()
                        .ExistAsync(s => s.Id == studentId && s.StudentStates
                        .Any(ss => ss.SubjectId == subjResponse.PreReqSubject.Id && ss.AcademicState == StudentStateEnum.ACHIEVED));
                }
            }
            catch (Exception ex)
            {
                HandleSVCException(response, ex);
            }

            return response;
        }
    }
}
