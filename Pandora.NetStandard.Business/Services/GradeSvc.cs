using Microsoft.Extensions.Logging;
using Pandora.NetStandard.Business.Mappers;
using Pandora.NetStandard.Business.Services.Contracts;
using Pandora.NetStdLibrary.Base.Base;
using Pandora.NetStdLibrary.Base.Interfaces;
using Pandora.NetStdLibrary.Base.Utils;
using Pandora.NetStandard.Model.Dtos;
using Pandora.NetStandard.Model.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Pandora.NetStandard.Business.Services
{
    public class GradeSvc : BaseService<Grade, GradeDto>, IGradeSvc
    {

        public GradeSvc(IIdentityAppUow applicationUow, ILogger<GradeSvc> logger) : base(applicationUow, logger, new GradeToDtoMapper())
        {

        }

        public async Task<BLSingleResponse<GradeDto>> CreateAsync(GradeDto pDto)
        {
            var response = new BLSingleResponse<GradeDto>();

            try
            {
                var entity = await _uow.GetRepository<Grade>().InsertAsync(pDto);
                if (!await _uow.CommitAsync())
                {
                    HandleSVCException(response, "This action couldn't be performed.");
                }
                response.Data = _mapper.MapEntity(entity);

            }
            catch (Exception ex)
            {
                HandleSVCException(response, ex);
            }

            return response;
        }

        public async Task<BLSingleResponse<bool>> DeleteAsync(GradeDto pDto)
        {
            var response = new BLSingleResponse<bool>();

            try
            {
                //var entity = await _uow.GetRepo<Grade>().GetByIdAsync(pDto.Id);
                await _uow.GetRepository<Grade>().DeleteAsync(pDto);
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

        public async Task<BLListResponse<GradeDto>> GetAllAsync()
        {
            var response = new BLListResponse<GradeDto>();

            try
            {
                var entity = await _uow.GetRepository<Grade>().AllAsync(null, o => o.OrderBy(g => g.Id), null);
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
                var entity = await _uow.GetRepository<Grade>().GetByIdAsync(pId);
                response.Data = _mapper.MapEntity(entity);
            }
            catch (Exception ex)
            {
                HandleSVCException(response, ex);
            }

            return response;
        }

        public async Task<BLSingleResponse<bool>> UpdateAsync(GradeDto pDto)
        {
            var response = new BLSingleResponse<bool>();

            try
            {

            }
            catch (Exception ex)
            {
                HandleSVCException(response, ex);
            }

            return response;
        }
    }
}
