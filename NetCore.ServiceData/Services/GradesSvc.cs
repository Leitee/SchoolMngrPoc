using NetCore.Core.Bases;
using NetCore.Core.Interfaces;
using NetCore.Model.Entities;
using NetCore.ServiceData.Services.Contracts;
using NetCore.ServiceData.Services.Dtos;
using NetCore.ServiceData.Services.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.ServiceData.Services
{
    public class GradesSvc : BaseService<Grade, GradeDto>, IGradeSvc
    {

        public GradesSvc(IApplicationUow applicationUow) : base(applicationUow, new GradeToDtoMapper())
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
                var entity = await _uow.Grades.GetByIdAsync(pId);
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
