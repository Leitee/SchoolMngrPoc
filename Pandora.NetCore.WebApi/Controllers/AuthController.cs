using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pandora.NetStandard.Business.Dtos;
using Pandora.NetStandard.Business.Services.Contracts;
using Pandora.NetStandard.Core.Bases;
using System.Threading.Tasks;

namespace Pandora.NetCore.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ApiBaseController
    {
        private readonly IAuthSvc _authSvc;

        public AuthController(ILogger<AuthController> logger, IAuthSvc authSvc) : base(logger)
        {
            _authSvc = authSvc;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            if (ModelState.IsValid)
            {
                var response = await _authSvc.LoginAsync(model);
                return response.ToHttpResponse();
            }
            return BadRequest();
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto model)
        {
            if (ModelState.IsValid)
            {
                var response = await _authSvc.RegisterAsync(model);
                return response.ToHttpResponse();
            }
            return BadRequest();
        }
    }
}