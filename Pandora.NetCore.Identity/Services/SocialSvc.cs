using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Pandora.NetCore.Identity.Services.Contracts;
using Pandora.NetStdLibrary.Base.Base;
using Pandora.NetStdLibrary.Base.Identity;
using Pandora.NetStdLibrary.Base.Interfaces;
using Pandora.NetStdLibrary.Base.Utils;
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
        private readonly IJwtTokenProvider _tokenProvider;

        public SocialSvc(
            ILogger logger,
            IAuthenticationSchemeProvider schemeProvider,
            AccountManagerFacade accountManager,
            UserManagerFacade userManager,
            IJwtTokenProvider tokenProvider
            ) : base(logger)
        {
            _schemeProvider = schemeProvider;
            _accountManager = accountManager;
            _userManager = userManager;
            _tokenProvider = tokenProvider;
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

        public async Task<BLSingleResponse<string>> HandleExternalLoginAsync()
        {
            var response = new BLSingleResponse<string>();

            try
            {
                //retrieves user information stored in a cookie
                var extLoginInfo = await _accountManager.GetExternalLoginInfoAsync();

                //check if the user has previously logged in using the external login provider
                var result = await _accountManager.ExternalLoginSignInAsync(extLoginInfo.LoginProvider, extLoginInfo.ProviderKey, isPersistent: false);

                if (result.Succeeded) //user does already exist 
                {
                    var user = await _accountManager.UserManager.FindByNameAsync(_accountManager.Context.User.Identity.Name);
                    var role = await _accountManager.GetRoleByUserAsync(user);
                    response.Data = _tokenProvider.GenerateToken(user, role).Token;
                }
                else //user does not exist yet
                {
                    var defaultRole = new ApplicationRole(RolesEnum.STUDENT.GetDescription());
                    var email = extLoginInfo.Principal.FindFirstValue(ClaimTypes.Email);

                    ApplicationUser newUser = _userManager.Users.SingleOrDefault(u => u.Email == email);

                    if (newUser == null)
                    {
                        newUser = new ApplicationUser(email.Split('@')[0], email,
                            extLoginInfo.Principal.FindFirstValue(ClaimTypes.GivenName),
                            extLoginInfo.Principal.FindFirstValue(ClaimTypes.Surname))
                        {
                            EmailConfirmed = true
                        };

                        var createResult = await _userManager.CreateAsync(newUser, new List<ApplicationRole> { defaultRole });

                        if (!createResult.Succeeded)
                            throw new Exception(createResult.Errors.Select(e => e.Description)
                                .Aggregate((errors, error) => $"{errors}, {error}"));
                    }

                    //associate the new user with the external login provider
                    await _userManager.AddLoginAsync(newUser, extLoginInfo);

                    var newUserClaims = extLoginInfo.Principal.Claims;
                    newUserClaims.Append(new Claim("userid", newUser.Id.ToString()));
                    newUserClaims.Append(new Claim(ClaimTypes.Role, defaultRole.Name));

                    await _userManager.AddClaimsAsync(newUser, newUserClaims);
                    await _accountManager.SignInAsync(newUser.UserName, newUser.PasswordHash, false);

                    response.Data = _tokenProvider.GenerateToken(newUser, defaultRole).Token;
                }
            }

            catch (Exception ex)
            {
                HandleSVCException(ex);
            }

            return response;
        }

        public async Task<BLSingleResponse<AuthenticationProperties>> SignInWithFacebookAsync(string redirectUrl)
        {
            var response = new BLSingleResponse<AuthenticationProperties>();

            await Task.Run(() =>
            {
                response.Data = _accountManager.ConfigureExternalAuthenticationProperties("Facebook", redirectUrl);
            });

            return response;
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
