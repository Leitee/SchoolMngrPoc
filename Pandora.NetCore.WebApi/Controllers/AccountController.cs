using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pandora.NetCore.WebApi.Controllers;
using Pandora.NetStandard.BusinessData.Dtos;
using Pandora.NetStandard.BusinessData.Services.Contracts;
using Pandora.NetStandard.Core.Bases;

namespace Pandora.Api.Controllers
{
    [Route("api/v1/[controller]")]
    public class AccountController : ApiBaseController
    {
        private readonly IAccountSvc _accountSvc;

        public AccountController(ILogger<AccountController> logger,
            IAccountSvc accountSvc) : base(logger)
        {
            _accountSvc = accountSvc;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            if(ModelState.IsValid)
            {
                var response = await _accountSvc.LoginAsync(model);
                return response.ToHttpResponse();
            }
            return BadRequest();
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto model)
        {
            if (ModelState.IsValid)
            {
                var response = await _accountSvc.RegisterAsync(model);
                return response.ToHttpResponse();
            }
            return BadRequest();
        }
    }
}