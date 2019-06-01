using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pandora.NetCore.Identity.Services.Contracts;
using Pandora.NetStandard.Core.Base;
using Pandora.NetStandard.Core.Utils;
using Pandora.NetStandard.Model.Dtos;
using System.Threading.Tasks;

namespace Pandora.NetCore.Identity.Controllers
{
    [Route("auth/v1")]
    public class AuthController : ApiBaseController
    {
        private readonly IAuthSvc _authSvc;

        public AuthController(ILogger<AuthController> logger, IAuthSvc authSvc) : base(logger)
        {
            _authSvc = authSvc;
        }

        [HttpGet]
        public ActionResult HeatltTest()
        {
            return Ok("AuthServer is Healty...");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            if (ModelState.IsValid)
            {
                var svc = await _authSvc.LoginAsync(model);
                return svc.ToHttpResponse();
            }
            return BadRequest(ModelState);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto model)
        {
            if (ModelState.IsValid)
            {
                var regSvc = await _authSvc.RegisterAsync(model);

                if (regSvc.HasError)
                {
                    return regSvc.ToHttpResponse();
                }

                if (true) //TODO: ask if email confirmation is requiered and fix url
                {
                    var token = await _authSvc.GetEmailConfirmTokenAsync(regSvc.Data);
                    var confirmUrl = Url.Action("ConfirmEmail", "Account", new
                    {
                        userid = regSvc.Data.Id,
                        token
                    }, protocol: HttpContext.Request.Scheme);

                    await _authSvc.SendEmailAsync(model.Email, confirmUrl);
                }

                var logSvc = await _authSvc.LoginAsync(model);
                return logSvc.ToHttpResponse();
            }
            return BadRequest(ModelState);
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            var svc = await _authSvc.LogoutAsync();
            return svc.ToHttpResponse();
        }
    }
}
