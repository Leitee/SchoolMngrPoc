using NetCore.Core.Bases;
using NetCore.Core.Interfaces;
using NetCore.Core.Mapper;
using System;

namespace NetCore.ServiceData.Services
{
    public abstract class BaseService<TEntity, TDto>
    {
        protected readonly IApplicationUow _uow;
        protected readonly IMapperCore<TEntity, TDto> _mapper;

        public BaseService(IApplicationUow applicationUow, IMapperCore<TEntity, TDto> mapperCore)
        {
            _uow = applicationUow;
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
