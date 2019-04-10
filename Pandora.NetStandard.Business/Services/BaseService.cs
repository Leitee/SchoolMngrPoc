﻿using Microsoft.Extensions.Logging;
using Pandora.NetStandard.Core.Bases;
using Pandora.NetStandard.Core.Interfaces;
using Pandora.NetStandard.Core.Mapper;
using Pandora.NetStandard.Data.Dals;
using System;
using System.Collections.Generic;

namespace Pandora.NetStandard.Business.Services
{
    public abstract class BaseService
    {
        protected readonly ApplicationUow _uow;
        protected readonly ILogger _logger;

        public BaseService(IApplicationUow applicationUow, ILogger logger)
        {
            _logger = logger;
            _logger?.LogInformation($"Access to service : {DateTime.UtcNow}");
            _uow = applicationUow as ApplicationUow;
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
