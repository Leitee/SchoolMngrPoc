using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace NetCore.Api.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AuthorizeController : ApiController
    {
        public AuthorizeController(ILogger<AuthorizeController> logger) : base(logger)
        {
        }

        [HttpGet]
        [AllowAnonymous]
        public string Protected()
        {
            return "Only if you have a valid token!";
        }
    }
}