using Microsoft.Extensions.Logging;
using Pandora.NetStandard.Business.Mappers;
using Pandora.NetStandard.Business.Services.Contracts;
using Pandora.NetStandard.Core.Bases;
using Pandora.NetStandard.Core.Interfaces;
using Pandora.NetStandard.Model.Dtos;
using Pandora.NetStandard.Model.Entities;
using System;
using System.Threading.Tasks;

namespace Pandora.NetStandard.Business.Services
{
    public class StudentStateSvc : BaseService<StudentState, StudentStateDto>, IStudentStateSvc
    {
        public StudentStateSvc(IApplicationUow applicationUow, ILogger logger) : base(applicationUow, logger, new StudentStateToDtoMapper())
        {
        }

        public async Task<BLSingleResponse<StudentStateDto>> CreateAsync(StudentStateDto pDto)
        {
            var response = new BLSingleResponse<StudentStateDto>();

            try
            {
                var entityResult = await _uow.GetRepo<StudentState>().InsertAsync(pDto);
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

        public Task<BLSingleResponse<bool>> DeleteAsync(StudentStateDto pDto)
        {
            throw new NotImplementedException();
        }

        public Task<BLListResponse<StudentStateDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<BLSingleResponse<StudentStateDto>> GetByIdAsync(int pId)
        {
            throw new NotImplementedException();
        }

        public async Task<BLSingleResponse<StudentStateDto>> GetLastValidStateAsync(StudentDto studentDto, SubjectDto subjectDto)
        {
            return new BLSingleResponse<StudentStateDto>();
        }

        public Task<BLSingleResponse<bool>> UpdateAsync(StudentStateDto pDto)
        {
            throw new NotImplementedException();
        }
    }
}
