using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Pandora.NetStandard.Core.Interfaces.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pandora.NetStandard.Core.Identity
{
    public class SignInManagerFacade : SignInManagerFacade<ApplicationUser>, ISignInManagerFacade
    {
        public SignInManagerFacade(IUserRepository userManager, IHttpContextAccessor contextAccessor, IUserClaimsPrincipalFactory<ApplicationUser> claimsFactory, IOptions<IdentityOptions> optionsAccessor, ILogger<SignInManager<ApplicationUser>> logger, IAuthenticationSchemeProvider schemes) : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemes)
        {
        }
    }

    public class SignInManagerFacade<TUser> : SignInManager<TUser>, ISignInManagerFacade<TUser> where TUser : ApplicationUser
    {
        public SignInManagerFacade(IUserRepository userManager, 
            IHttpContextAccessor contextAccessor, 
            IUserClaimsPrincipalFactory<TUser> claimsFactory, 
            IOptions<IdentityOptions> optionsAccessor, 
            ILogger<SignInManager<TUser>> logger, 
            IAuthenticationSchemeProvider schemes) 
            : base(userManager as UserManager<TUser>, contextAccessor, claimsFactory, optionsAccessor, logger, schemes)
        {           
            UserManager = userManager;
        }

        public new IUserRepository UserManager { get; }

        public virtual async Task<IdentityResult> SignUpAsync<TRole>(TUser user, string pPassword, IEnumerable<TRole> roles) where TRole : ApplicationRole
        {
            user.PasswordHash = new PasswordHasher<TUser>().HashPassword(user, pPassword);
            return await UserManager.CreateAsync(user, roles);
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
