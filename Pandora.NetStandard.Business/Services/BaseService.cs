using Pandora.NetStandard.Core.Bases;
using Pandora.NetStandard.Core.Interfaces;
using Pandora.NetStandard.Core.Mapper;
using Pandora.NetStandard.Data.Dals;
using System;

namespace Pandora.NetStandard.Business.Services
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

    public abstract class BaseService<TEntity, TDto> : BaseService where TEntity : IEntity where TDto : class
    {
        protected readonly IMapperCore<TEntity, TDto> _mapper;

        public BaseService(IApplicationUow applicationUow, IMapperCore<TEntity, TDto> mapperCore) : base(applicationUow)
        {
            _mapper = mapperCore;
        }
    }
}
