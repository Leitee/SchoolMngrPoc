using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace NetCore.Api.Controllers
{
    [ApiController]
    public abstract class ApiController : ControllerBase
    {
        protected readonly ILogger _logger;

        public ApiController(ILogger logger)
        {
            logger.LogInformation("Application Starting");
            _logger = logger;
        }
    }
}