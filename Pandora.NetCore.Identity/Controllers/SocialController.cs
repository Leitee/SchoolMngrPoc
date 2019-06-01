using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Pandora.NetCore.Identity.Services;
using Pandora.NetCore.Identity.Services.Contracts;
using Pandora.NetStandard.Core.Base;
using Pandora.NetStandard.Core.Config;
using Pandora.NetStandard.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pandora.NetCore.Identity.Controllers
{
    [Route("auth/v1/[controller]")]
    public class SocialController : ApiBaseController
    {
        private readonly ISocialSvc _socialSvc;
        private readonly AppSettings _appSettings;

        public SocialController(ILogger<SocialController> logger,
            IConfiguration config,
            ISocialSvc socialSvc) : base(logger)
        {
            _appSettings = AppSettings.GetSettings(config ?? throw new ArgumentNullException(nameof(config)));
            _socialSvc = socialSvc;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSocialProviders()
        {
            var svc = await _socialSvc.GetAllSocialProvidersAsync();
            return svc.ToHttpResponse();
        }

        [HttpGet("Facebook")]
        public async Task<IActionResult> SignInWithFacebook()
        {
            var svc = await _socialSvc.SignInWithFacebookAsync(Url.Action(nameof(HandleExternalLogin)));
            return Challenge(svc.Data, "Facebook");
        }

        [HttpGet("Google")]
        public async Task<IActionResult> SignInWithGoogle()
        {
            var svc = await _socialSvc.SignInWithGoogleAsync(Url.Action(nameof(HandleExternalLogin)));
            return Challenge(svc.Data, "Google");
        }

        [HttpGet("ExternalLogin")]
        public async Task<IActionResult> HandleExternalLogin()
        {
            await _socialSvc.HandleExternalLoginAsync();

            // sign out from IdentityConstants.ExternalScheme and remove external provider info
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            return Redirect($"{_appSettings.WebClientUrl}/auth/login?external={HttpContext.User.Identity.IsAuthenticated}");
        }
    }
}