using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pandora.NetCore.Identity.Services.Contracts;
using Pandora.NetStandard.Core.Base;
using Pandora.NetStandard.Core.Filters;
using Pandora.NetStandard.Core.Utils;
using Pandora.NetStandard.Model.Dtos;
using System;
using System.Threading.Tasks;

namespace Pandora.NetCore.Identity.Controllers
{
    //[ServiceFilter(typeof(SingleLoggerAsyncFilter))]
    [Route("auth/v1")]
    public class AuthController : ApiBaseController
    {
        private readonly IAuthSvc _authSvc;

        public AuthController(ILogger logger, IAuthSvc authSvc) : base(logger)
        {
            _authSvc = authSvc;
        }

        [Route("/")]
        [HttpGet]
        public ActionResult HeatltTest()
        {
            return Ok("IdentityServer is Healty...");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
                ModelState.AddModelError("Error", "This user is already logged in.");

            var svc = await _authSvc.LoginAsync(model);
            return svc.ToHttpResponse();
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto model)
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

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            var svc = await _authSvc.LogoutAsync();
            return svc.ToHttpResponse();
        }
    }
}
