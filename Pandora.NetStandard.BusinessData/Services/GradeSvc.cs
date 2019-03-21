using Pandora.NetStandard.BusinessData.Dtos;
using Pandora.NetStandard.BusinessData.Mappers;
using Pandora.NetStandard.BusinessData.Services.Contracts;
using Pandora.NetStandard.Core.Bases;
using Pandora.NetStandard.Core.Interfaces;
using Pandora.NetStandard.Model.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Pandora.NetStandard.BusinessData.Services
{
    public class GradeSvc : BaseService<Grade, GradeDto>, IGradeSvc
    {

        public GradeSvc(IApplicationUow applicationUow) : base(applicationUow, new GradeToDtoMapper())
        {

        }

        public Task<BLSingleResponse<GradeDto>> CreateAsync(GradeDto pDto)
        {
            throw new NotImplementedException();
        }

        public Task<BLSingleResponse<bool>> DeleteAsync(GradeDto pDto)
        {
            throw new NotImplementedException();
        }

        public async Task<BLListResponse<GradeDto>> GetAllAsync()
        {
            var response = new BLListResponse<GradeDto>();

            try
            {
                var entity = await _uow.Grades.AllAsync(null, o => o.OrderBy(g => g.GradeId), null);
                response.Data = _mapper.MapEntity(entity);
            }
            catch (Exception ex)
            {
                HandleSVCException(response, ex);
            }

            return response;
        }

        public async Task<BLSingleResponse<GradeDto>> GetByIdAsync(int pId)
        {
            var response = new BLSingleResponse<GradeDto>();

            try
            {
                var entity = await _uow.Grades.FindAsync(g => g.GradeId == pId, g => g.Classes);
                response.Data = _mapper.MapEntity(entity);
            }
            catch (Exception ex)
            {
                HandleSVCException(response, ex);
            }

            return response;
        }

        public Task<BLSingleResponse<bool>> UpdateAsync(GradeDto pDto)
        {
            throw new NotImplementedException();
        }
    }
}
