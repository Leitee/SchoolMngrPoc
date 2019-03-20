using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Pandora.Api.Controllers
{
    [Produces("application/json")]
    [ApiController]
    public abstract class ApiBaseController : ControllerBase
    {
        protected readonly ILogger _logger;

        public ApiBaseController(ILogger logger)
        {
            logger.LogInformation("Application Starting...");
            _logger = logger;
        }
    }
}