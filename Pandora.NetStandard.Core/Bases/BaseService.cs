using Microsoft.Extensions.Logging;
using Pandora.NetStandard.Core.Interfaces;
using Pandora.NetStandard.Core.Mapper;
using System;
using System.Collections.Generic;

namespace Pandora.NetStandard.Core.Util
{
    public abstract class BaseService
    {
        protected readonly IApplicationUow _uow;
        protected readonly ILogger _logger;

        public BaseService(IApplicationUow applicationUow, ILogger logger)
        {
            _logger = logger;
            _logger?.LogInformation($"Accessing to service : {DateTime.UtcNow}");
            _uow = applicationUow;
        }

        protected void HandleSVCException(BLResponse pResponse, Exception pEx)
        {
            List<string> errs = new List<string>();
            do
            {
                errs.Add(pEx.Message);
                pEx = pEx.InnerException;

            } while (pEx != null);

            HandleSVCException(pResponse, errs.ToArray());
        }
        //TODO: response generic error msg on prod mode
        protected void HandleSVCException(BLResponse pResponse, params string[] pErrors)
        {
            string defaultMsg = "Internal Error at Service Layer. ";
            _logger?.LogError(defaultMsg, pErrors);
            pResponse.Errors.Add(defaultMsg);
            pResponse.Errors.AddRange(pErrors);
        }
    }

    public abstract class BaseService<TEntity, TDto> : BaseService where TEntity : IEntity where TDto : class
    {
        protected readonly IMapperCore<TEntity, TDto> _mapper;

        public BaseService(IApplicationUow applicationUow, ILogger logger, IMapperCore<TEntity, TDto> mapperCore) : base(applicationUow, logger)
        {
            _mapper = mapperCore;
        }
    }
}
