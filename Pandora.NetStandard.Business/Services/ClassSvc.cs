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
    public class ClassSvc : BaseService<Class, ClassDto>, IClassSvc
    {

        public ClassSvc(IApplicationUow applicationUow) : base(applicationUow, new ClassToDtoMapper())
        {

        }

        public async Task<BLSingleResponse<ClassDto>> CreateAsync(ClassDto pDto)
        {
            var response = new BLSingleResponse<ClassDto>();

            try
            {                
                var entity = await _uow.Classes.InsertAsync(pDto);
                if (!await _uow.CommitAsync())
                {
                    HandleSVCException(response, "New Class creation failed.");
                }
                response.Data = _mapper.MapEntity(entity);

            }
            catch (Exception ex)
            {
                HandleSVCException(response, ex);
            }

            return response;
        }

        public Task<BLSingleResponse<bool>> DeleteAsync(ClassDto pDto)
        {
            throw new NotImplementedException();
        }

        public async Task<BLListResponse<ClassDto>> GetAllAsync()
        {
            var response = new BLListResponse<ClassDto>();

            try
            {
                var entity = await _uow.Classes.AllAsync(null, o => o.OrderBy(g => g.GradeId), g => g.Grade);
                response.Data = _mapper.MapEntity(entity);
            }
            catch (Exception ex)
            {
                HandleSVCException(response, ex);
            }

            return response;
        }

        public async Task<BLSingleResponse<ClassDto>> GetByIdAsync(int pId)
        {
            var response = new BLSingleResponse<ClassDto>();

            try
            {
                var entity = await _uow.Classes.FindAsync(g => g.GradeId == pId, g => g.Grade);
                response.Data = _mapper.MapEntity(entity);
            }
            catch (Exception ex)
            {
                HandleSVCException(response, ex);
            }

            return response;
        }

        public Task<BLSingleResponse<bool>> UpdateAsync(ClassDto pDto)
        {
            throw new NotImplementedException();
        }
    }
}
