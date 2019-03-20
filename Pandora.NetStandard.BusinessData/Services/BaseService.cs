using System;
using Pandora.NetStandard.BusinessData.Data;
using Pandora.NetStandard.Core.Bases;
using Pandora.NetStandard.Core.Interfaces;
using Pandora.NetStandard.Core.Mapper;

namespace Pandora.NetStandard.BusinessData.Services
{
    public abstract class BaseService<TEntity, TDto>
    {
        protected readonly ApplicationUow _uow;
        protected readonly IMapperCore<TEntity, TDto> _mapper;

        public BaseService(IApplicationUow applicationUow, IMapperCore<TEntity, TDto> mapperCore)
        {
            _uow = applicationUow as ApplicationUow;
            _mapper = mapperCore;
        }

        protected void HandleSVCException(BLResponse pResponse, Exception pEx)
        {
            pResponse.Errors.Add("Internal Error at Service Layer");
            pResponse.Errors.Add(pEx.Message);
            if (pEx.InnerException != null)
                pResponse.Errors.Add(pEx.InnerException.Message);
        }

        protected void HandleSVCException(BLResponse pResponse, params string[] pErrors)
        {
            pResponse.Errors.Add("Internal Error at Service Layer");
            pResponse.Errors.AddRange(pErrors);
        }
    }
}
