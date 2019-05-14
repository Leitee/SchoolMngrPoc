using Microsoft.Extensions.Logging;
using Pandora.NetStandard.Business.Mappers;
using Pandora.NetStandard.Business.Services.Contracts;
using Pandora.NetStandard.Core.Bases;
using Pandora.NetStandard.Core.Interfaces;
using Pandora.NetStandard.Model.Dtos;
using Pandora.NetStandard.Model.Entities;
using Pandora.NetStandard.Model.Enums;
using System;
using System.Collections.Generic;
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
                Student studentEntity = pDto;
                studentEntity.SubjectStates = new List<StudentState> { new StudentState() {
                    DateFrom = DateTime.Now,
                    AcademicState = SubjectStateEnum.SUBSCRIBED,
                    Student = studentEntity,
                } };
                var entityResult = await _uow.GetRepo<Student>().InsertAsync(studentEntity);
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

        public async Task<BLListResponse<StudentDto>> GetAllExamsResultsByClass(int pClassId)
        {
            var response = new BLListResponse<StudentDto>();

            try
            {
                var entityReult = await _uow.GetRepo<Student>().AllAsync(null, null, s => s.SubjectStates.Any(st => st.AcademicState == SubjectStateEnum.IN_PROGRESS));
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
                var entityResult = await _uow.GetRepo<Student>().FindAsync(s => s.Id == pId, s => s.Class);
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
    }
}
