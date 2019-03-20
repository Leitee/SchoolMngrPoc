using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace NetCore.Api.Controllers
{
    [Produces("application/json")]
    [ApiController]
    public abstract class ApiController : ControllerBase
    {
        protected readonly ILogger _logger;

        public ApiController(ILogger logger)
        {
            logger.LogInformation("Application Starting...");
            _logger = logger;
        }
    }
}