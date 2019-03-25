using Pandora.NetStandard.Business.Dtos;
using Pandora.NetStandard.Business.Mappers;
using Pandora.NetStandard.Business.Services.Contracts;
using Pandora.NetStandard.Core.Bases;
using Pandora.NetStandard.Core.Interfaces;
using Pandora.NetStandard.Model.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Pandora.NetStandard.Business.Services
{
    public class ClassSvc : BaseService, IClassSvc
    {

        public ClassSvc(IApplicationUow applicationUow) : base(applicationUow)
        {

        }

        public Task<BLSingleResponse<Class>> CreateAsync(Class pDto)
        {
            throw new NotImplementedException();
        }

        public Task<BLSingleResponse<bool>> DeleteAsync(Class pDto)
        {
            throw new NotImplementedException();
        }

        public async Task<BLListResponse<Class>> GetAllAsync()
        {
            var response = new BLListResponse<Class>();

            try
            {
                var entity = await _uow.Classes.AllAsync(null, o => o.OrderBy(g => g.ClassId), g => g.Grade);
                response.Data = entity;
            }
            catch (Exception ex)
            {
                HandleSVCException(response, ex);
            }

            return response;
        }

        public async Task<BLSingleResponse<Class>> GetByIdAsync(int pId)
        {
            var response = new BLSingleResponse<Class>();

            try
            {
                var entity = await _uow.Classes.FindAsync(g => g.GradeId == pId, g => g.Grade);
                response.Data = entity;
            }
            catch (Exception ex)
            {
                HandleSVCException(response, ex);
            }

            return response;
        }

        public Task<BLSingleResponse<bool>> UpdateAsync(Class pDto)
        {
            throw new NotImplementedException();
        }
    }
}
