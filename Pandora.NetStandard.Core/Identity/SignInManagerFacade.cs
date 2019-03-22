using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Pandora.NetStandard.Core.Interfaces.Identity;
using Pandora.NetStandard.Core.Security.Identity;
using System.Threading.Tasks;

namespace Pandora.NetStandard.Core.Identity
{
    public class SignInManagerFacade<TUser> : SignInManager<TUser>, ISignInManagerFacade<TUser> where TUser : ApplicationUser
    {
        public SignInManagerFacade(UserManager<TUser> userManager, 
            IHttpContextAccessor contextAccessor, 
            IUserClaimsPrincipalFactory<TUser> claimsFactory, 
            IOptions<IdentityOptions> optionsAccessor, 
            ILogger<SignInManager<TUser>> logger, 
            IAuthenticationSchemeProvider schemes) 
            : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemes)
        {
        }

        public virtual async Task<IdentityResult> SignUpAsync(TUser user, string pPassword)
        {
            return await UserManager.CreateAsync(user, pPassword);
        }

        public virtual async Task<SignInResult> SignInAsync(string pUsername, string pPassword, bool pRememberMe)
        {
            return await PasswordSignInAsync(pUsername, pPassword, pRememberMe, false);
        }

        public override Task SignOutAsync()
        {
            return base.SignOutAsync();
        } 
    }
}
