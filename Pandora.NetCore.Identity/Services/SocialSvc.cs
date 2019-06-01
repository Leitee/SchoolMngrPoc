using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Pandora.NetCore.Identity.Services.Contracts;
using Pandora.NetStandard.Core.Base;
using Pandora.NetStandard.Core.Identity;
using Pandora.NetStandard.Core.Interfaces;
using Pandora.NetStandard.Core.Mapper;
using Pandora.NetStandard.Core.Utils;
using Pandora.NetStandard.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Pandora.NetCore.Identity.Services
{
    public class SocialSvc : BaseService, ISocialSvc
    {
        private readonly IAuthenticationSchemeProvider _schemeProvider;
        private readonly AccountManagerFacade _accountManager;
        private readonly UserManagerFacade _userManager;
        private readonly IMapperCore _mapper;

        public SocialSvc(IApplicationUow applicationUow,
            ILogger logger,
            IAuthenticationSchemeProvider schemeProvider,
            AccountManagerFacade accountManager,
            UserManagerFacade userManager,
            IMapperCore mapper
            ) : base(applicationUow, logger)
        {
            _schemeProvider = schemeProvider;
            _accountManager = accountManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<BLListResponse<string>> GetAllSocialProvidersAsync()
        {
            var response = new BLListResponse<string>();

            try
            {
                var providers = await _schemeProvider.GetAllSchemesAsync();
                response.Data = providers.Select(p => p.DisplayName).Where(n => !string.IsNullOrEmpty(n));
            }
            catch (Exception ex)
            {
                HandleSVCException(response, ex);
            }

            return response;
        }

        public async Task<BLResponse> HandleExternalLoginAsync()
        {
            try
            {
                //retrieves user information stored in a cookie
                var extLoginInfo = await _accountManager.GetExternalLoginInfoAsync();

                //check if the user has previously logged in using the external login provider
                var result = await _accountManager.ExternalLoginSignInAsync(extLoginInfo.LoginProvider, extLoginInfo.ProviderKey, isPersistent: false);

                if (!result.Succeeded) //user does not exist yet
                {
                    var email = extLoginInfo.Principal.FindFirstValue(ClaimTypes.Email);
                    var newUser = new ApplicationUser(email.Split('@')[0], email,
                        extLoginInfo.Principal.FindFirstValue(ClaimTypes.GivenName),
                        extLoginInfo.Principal.FindFirstValue(ClaimTypes.Surname))
                    {
                        EmailConfirmed = true
                    };

                    var createResult = await _userManager.CreateAsync(newUser, new List<ApplicationRole>
                    {
                        new ApplicationRole(RolesEnum.STUDENT.GetDescription())
                    });

                    if (!createResult.Succeeded)
                        throw new Exception(createResult.Errors.Select(e => e.Description)
                            .Aggregate((errors, error) => $"{errors}, {error}"));

                    //associate the new user with the external login provider
                    await _userManager.AddLoginAsync(newUser, extLoginInfo);

                    var newUserClaims = extLoginInfo.Principal.Claims;
                    newUserClaims.Append(new Claim("userid", newUser.Id.ToString()));
                    newUserClaims.Append(new Claim(ClaimTypes.Role, RolesEnum.STUDENT.GetDescription()));

                    await _userManager.AddClaimsAsync(newUser, newUserClaims);
                    await _accountManager.SignInAsync(newUser, isPersistent: false);                    
                }
            }

            catch (Exception ex)
            {
                HandleSVCException(ex);
            }

            return BLResponse.GetVoidResponse();
        }

        public async Task<BLSingleResponse<AuthenticationProperties>> SignInWithFacebookAsync(string redirectUrl)
        {
            throw new NotImplementedException();
        }

        public async Task<BLSingleResponse<AuthenticationProperties>> SignInWithGoogleAsync(string redirectUrl)
        {
            var response = new BLSingleResponse<AuthenticationProperties>();

            await Task.Run(() =>
            {
                response.Data = _accountManager.ConfigureExternalAuthenticationProperties("Google", redirectUrl);
            });

            return response;
        }
    }
}
