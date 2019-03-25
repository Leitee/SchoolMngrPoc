using System;
using Pandora.NetStandard.BusinessData.Data;
using Pandora.NetStandard.Core.Bases;
using Pandora.NetStandard.Core.Interfaces;
using Pandora.NetStandard.Core.Mapper;

namespace Pandora.NetStandard.BusinessData.Services
{
    public abstract class BaseService
    {
        protected readonly ApplicationUow _uow;

        public BaseService(IApplicationUow applicationUow)
        {
            _uow = applicationUow as ApplicationUow;
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

    public abstract class BaseService<TEntity, TDto> : BaseService
    {
        protected readonly IMapperCore<TEntity, TDto> _mapper;

        public BaseService(IApplicationUow applicationUow, IMapperCore<TEntity, TDto> mapperCore) : base(applicationUow)
        {
            _mapper = mapperCore;
        }
    }
}
