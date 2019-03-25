using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pandora.NetCore.WebApi.Controllers;
using Pandora.NetStandard.Business.Services.Contracts;

namespace Pandora.Api.Controllers
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
    }
}