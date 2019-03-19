using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace NetCore.Api.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthorizeController : ApiController
    {
        public AuthorizeController(ILogger<AuthorizeController> logger) : base(logger)
        {
        }

        [HttpGet]
        //[Authorize]
        public string Protected()
        {
            return "Only if you have a valid token!";
        }
    }
}