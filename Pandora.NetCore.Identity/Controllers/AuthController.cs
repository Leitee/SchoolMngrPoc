using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pandora.NetStandard.Business.Services.Contracts;
using Pandora.NetStandard.Core.Bases;
using Pandora.NetStandard.Model.Dtos;
using System.Threading.Tasks;

namespace Pandora.NetCore.Identity.Controllers
{
    [Route("auth/v1")]
    [ApiController]
    public class AuthController : ApiBaseController
    {
        private readonly IAuthSvc _authSvc;

        public AuthController(ILogger<AuthController> logger, IAuthSvc authSvc) : base(logger)
        {
            _authSvc = authSvc;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            if (ModelState.IsValid)
            {
                var response = await _authSvc.LoginAsync(model);
                return response.ToHttpResponse();
            }
            return BadRequest(ModelState);
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto model)
        {
            if (ModelState.IsValid)
            {
                var register = await _authSvc.RegisterAsync(model);

                if (register.HasError)
                {
                    return register.ToHttpResponse();
                }

                if (true) //TODO: ask if email confirmation is requiered and fix url
                {
                    var token = await _authSvc.GetEmailConfirmTokenAsync(register.Data);
                    var confirmUrl = Url.Action("ConfirmEmail", "Account", new
                    {
                        userid = register.Data.Id,
                        token
                    }, protocol: HttpContext.Request.Scheme);

                    await _authSvc.SendEmailAsync(model.Email, confirmUrl);
                }

                var response = await _authSvc.LoginAsync(model);
                return response.ToHttpResponse();
            }
            return BadRequest(ModelState);
        }
    }
}
