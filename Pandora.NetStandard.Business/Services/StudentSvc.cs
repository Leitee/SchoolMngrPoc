using Microsoft.Extensions.Logging;
using Pandora.NetStandard.Business.Mappers;
using Pandora.NetStandard.Business.Services.Contracts;
using Pandora.NetStandard.Core.Interfaces;
using Pandora.NetStandard.Core.Base;
using Pandora.NetStandard.Core.Utils;
using Pandora.NetStandard.Model.Dtos;
using Pandora.NetStandard.Model.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Pandora.NetStandard.Business.Services
{
    public class StudentSvc : BaseService<Student, StudentDto>, IStudentSvc
    {
        public StudentSvc(IApplicationUow applicationUow, ILogger<StudentSvc> logger)
            : base(applicationUow, logger, new StudentToDtoMapper())
        {

        }

        public async Task<BLSingleResponse<StudentDto>> CreateAsync(StudentDto pDto)
        {
            var response = new BLSingleResponse<StudentDto>();

            try
            {
                var entityResult = await _uow.GetRepo<Student>().InsertAsync(pDto);
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

        public Task<BLSingleResponse<bool>> DeleteAsync(StudentDto pDto)
        {
            throw new NotImplementedException();
        }

        public Task<BLListResponse<StudentDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<BLListResponse<StudentDto>> GetStudentsAttendsBySubjectId(int pSubjectId)
        {
            var response = new BLListResponse<StudentDto>();

            try
            {
                var entityReult = await _uow.GetRepo<Student>()
                    .AllAsync(s => s.StudentStates.Any(ss => ss.SubjectId == pSubjectId),
                    null,
                    x => x.Include(s => s.ApplicationUser),
                    x => x.Include(s => s.StudentStates),
                    x => x.Include(s => s.Attends));

                response.Data = _mapper.MapEntity(entityReult);
            }
            catch (Exception ex)
            {
                HandleSVCException(response, ex);
            }

            return response;
        }

        public async Task<BLSingleResponse<bool>> SaveStudentExams(StudentDto pStudent)
        {
            var response = new BLSingleResponse<bool>();

            try
            {
                await _uow.GetRepo<Student>().UpdateAsync(pStudent);
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

        public async Task<BLSingleResponse<StudentDto>> GetByIdAsync(int pId)
        {
            var response = new BLSingleResponse<StudentDto>();

            try
            {
                var entityResult = await _uow.GetRepo<Student>().GetByIdAsync(pId);
                response.Data = _mapper.MapEntity(entityResult);
            }
            catch (Exception ex)
            {
                HandleSVCException(response, ex);
            }

            return response;
        }

        public Task<BLSingleResponse<bool>> UpdateAsync(StudentDto pDto)
        {
            throw new NotImplementedException();
        }

        public async Task<BLListResponse<StudentDto>> GetStudentsExamsBySubjectId(int pSubjectId)
        {
            var response = new BLListResponse<StudentDto>();

            try
            {
                var entityResult = await _uow.GetRepo<Student>()
                    .AllAsync(s => s.StudentStates.Any(ss => ss.SubjectId == pSubjectId),
                    null,
                    x => x.Include(s => s.ApplicationUser),
                    x => x.Include(s => s.StudentStates),
                    x => x.Include(s => s.Exams));

                response.Data = _mapper.MapEntity(entityResult);
            }
            catch (Exception ex)
            {
                HandleSVCException(response, ex);
            }

            return response;
        }
    }
}
