using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pandora.NetStandard.Business.Services.Contracts;
using Pandora.NetStdLibrary.Base.Base;
using Pandora.NetStdLibrary.Base.Utils;
using Pandora.NetStandard.Model.Dtos;
using System.Threading.Tasks;

namespace Pandora.NetStandard.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AccountController : ApiBaseController
    {
        private readonly IAccountSvc _accountSvc;

        public AccountController(ILogger logger,
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
        [HttpGet("ConfirmEmail")]
        public IActionResult ConfirmEmail()
        {
            return Ok();
        }

        [HttpGet("Roles")]
        public async Task<IActionResult> GetRoles()
        {
            var response = await _accountSvc.GetAllRolesAsync();
            return response.ToHttpResponse();
        }

        [HttpGet("Roles/{id}")]
        public async Task<IActionResult> GetRolesById(int id)
        {
            var response = await _accountSvc.GetRoleByIdAsync(id);
            return response.ToHttpResponse();
        }

        [HttpGet("Users")]
        public async Task<IActionResult> GetUsers()
        {
            var response = await _accountSvc.GetAllUsersAsync();
            return response.ToHttpResponse();
        }

        [HttpGet("Users/{id}")]
        public async Task<IActionResult> GetUsersById(int id)
        {
            var response = await _accountSvc.GetUserByIdAsync(id);
            return response.ToHttpResponse();
        }
    }
}