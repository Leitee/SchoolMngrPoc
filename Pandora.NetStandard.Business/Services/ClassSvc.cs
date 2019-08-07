using Microsoft.Extensions.Logging;
using Pandora.NetStandard.Business.Mappers;
using Pandora.NetStandard.Business.Services.Contracts;
using Pandora.NetStandard.Core.Base;
using Pandora.NetStandard.Core.Interfaces;
using Pandora.NetStandard.Core.Utils;
using Pandora.NetStandard.Model.Dtos;
using Pandora.NetStandard.Model.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Pandora.NetStandard.Business.Services
{
    public class ClassSvc : BaseService<Class, ClassDto>, IClassSvc
    {

        public ClassSvc(IIdentityAppUow applicationUow, ILogger<ClassSvc> logger) :
            base(applicationUow, logger, new ClassToDtoMapper())
        {

        }

        public async Task<BLSingleResponse<ClassDto>> CreateAsync(ClassDto pDto)
        {
            var response = new BLSingleResponse<ClassDto>();

            try
            {
                var entity = await _uow.GetRepository<Class>().InsertAsync(pDto);
                if (!await _uow.CommitAsync())
                {
                    HandleSVCException(response, "Class could not be created");
                }
                response.Data = _mapper.MapEntity(entity);

            }
            catch (Exception ex)
            {
                HandleSVCException(response, ex);
            }

            return response;
        }

        public async Task<BLSingleResponse<bool>> DeleteAsync(int classId)
        {
            var classResul = await _uow.GetRepository<Class>().GetByIdAsync(classId);
            return await DeleteAsync(_mapper.MapEntity(classResul));
        }

        public async Task<BLSingleResponse<bool>> DeleteAsync(ClassDto pDto)
        {
            var response = new BLSingleResponse<bool>();

            try
            {
                await _uow.GetRepository<Class>().DeleteAsync(pDto);
                if (!await _uow.CommitAsync())
                {
                    HandleSVCException(response, "Class could not be deleted");
                }
                response.Data = true;

            }
            catch (Exception ex)
            {
                HandleSVCException(response, ex);
            }

            return response;
        }

        public async Task<BLListResponse<ClassDto>> GetAllAsync()
        {
            var response = new BLListResponse<ClassDto>();

            try
            {
                var entity = await _uow.GetRepository<Class>().AllAsync(null, o => o.OrderBy(g => g.GradeId), null);
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
                var entity = await _uow.GetRepository<Class>().FindAsync(c => c.Id == pId, x => x.Include(c => c.Grade));
                response.Data = _mapper.MapEntity(entity);
            }
            catch (Exception ex)
            {
                HandleSVCException(response, ex);
            }

            return response;
        }

        public async Task<BLListResponse<ClassDto>> GetClassesByGradeId(int gradeId)
        {
            var response = new BLListResponse<ClassDto>();

            try
            {
                var entity = await _uow.GetRepository<Class>().AllAsync(c => c.GradeId == gradeId, null, null);
                response.Data = _mapper.MapEntity(entity);
            }
            catch (Exception ex)
            {
                HandleSVCException(response, ex);
            }

            return response;
        }

        public async Task<BLSingleResponse<bool>> UpdateAsync(ClassDto pDto)
        {
            var response = new BLSingleResponse<bool>();

            try
            {
                await _uow.GetRepository<Class>().UpdateAsync(pDto);
                if (!await _uow.CommitAsync())
                {
                    HandleSVCException(response, "Class could not be modified");
                }
                response.Data = true;

            }
            catch (Exception ex)
            {
                HandleSVCException(response, ex);
            }

            return response;
        }
    }
}
