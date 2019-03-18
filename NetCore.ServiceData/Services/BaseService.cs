using NetCore.Core.Bases;
using NetCore.Core.Interfaces;
using NetCore.Core.Mapper;
using System;

namespace NetCore.ServiceData.Services
{
    public abstract class BaseService<TEntity, TDto>
    {
        public BLResponse<TDto> Response { get; set; }
        protected readonly IApplicationUow _uow;
        protected readonly IMapperCore<TEntity, TDto> _mapper;

        public BaseService(IApplicationUow applicationUow, IMapperCore<TEntity, TDto> mapperCore)
        {
            _uow = applicationUow;
            _mapper = mapperCore;
            Response = new BLResponse<TDto>();
        }

        protected void HandleSVCException(Exception pEx)
        {
            Response.Errors.Add("Internal Error at Service Layer");
            Response.Errors.Add(pEx.Message);
            if (pEx.InnerException != null)
                Response.Errors.Add(pEx.InnerException.Message);
        }

        protected void HandleSVCException(params string[] pErrors)
        {
            Response.Errors.Add("Internal Error at Service Layer");
            Response.Errors.AddRange(pErrors);
        }
    }
}
