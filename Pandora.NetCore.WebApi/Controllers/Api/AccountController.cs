using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pandora.NetStandard.Business.Dtos;
using Pandora.NetStandard.Business.Services.Contracts;
using Pandora.NetStandard.Core.Bases;
using System.Threading.Tasks;

namespace Pandora.NetCore.WebApi.Controllers.Api
{
    [Route("api/v1/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AccountController : ApiBaseController
    {
        private readonly IAccountSvc _accountSvc;

        public AccountController(ILogger<AccountController> logger,
            IAccountSvc accountSvc) : base(logger)
        {
            _accountSvc = accountSvc;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            if (ModelState.IsValid)
            {
                var response = await _accountSvc.LoginAsync(model);
                return response.ToHttpResponse();
            }
            return BadRequest(ModelState.ValidationState);
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto model)
        {
            if (ModelState.IsValid)
            {
                var register = await _accountSvc.RegisterAsync(model);

                if (register.HasError)
                {
                    return register.ToHttpResponse();
                }

                if (true) //TODO: ask if email confirmation is requiered and fix url
                {
                    var token = await _accountSvc.GetEmailConfirmTokenAsync(register.Data);
                    var confirmUrl = Url.Action("ConfirmEmail", "Account", new
                    {
                        userid = register.Data.Id,
                        token
                    }, protocol: HttpContext.Request.Scheme);

                    await _accountSvc.SendEmailAsync(model.Email, confirmUrl);
                }

                var response = await _accountSvc.LoginAsync(model);
                return response.ToHttpResponse();
            }
            return BadRequest(ModelState.ValidationState);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> ConfirmEmail()
        {            
            return Ok();
        }
    }
}