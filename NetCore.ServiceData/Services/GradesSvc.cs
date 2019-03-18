using NetCore.Core.Bases;
using NetCore.Core.Interfaces;
using NetCore.Model.Entities;
using NetCore.ServiceData.Services.Contracts;
using NetCore.ServiceData.Services.Dtos;
using NetCore.ServiceData.Services.Mappers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCore.ServiceData.Services
{
    public class GradesSvc : BaseService<Grade, GradeDto>, IGradeSvc
    {
        private readonly GradeToDtoMapper _gradeToDtoMapper;

        public GradesSvc(IApplicationUow applicationUow) : base(applicationUow, new GradeToDtoMapper())
        {

        }

        public Task<BLResponse<GradeDto>> CreateAsync(GradeDto pDto)
        {
            throw new NotImplementedException();
        }

        public Task<BLResponse<bool>> DeleteAsync(GradeDto pDto)
        {
            throw new NotImplementedException();
        }

        public async Task<BLResponse<List<GradeDto>>> GetAllAsync()
        {            
            try
            {
                //Response.Data = _gradeToDtoMapper.MapEntity(await _uow.Grades.AllAsync(null, null, null));
            }
            catch (Exception ex)
            {
                HandleSVCException(ex);
            }

            return null;
        }

        public Task<BLResponse<GradeDto>> GetByIdAsync(int pId)
        {
            throw new NotImplementedException();
        }

        public Task<BLResponse<bool>> UpdateAsync(GradeDto pDto)
        {
            throw new NotImplementedException();
        }
    }
}
