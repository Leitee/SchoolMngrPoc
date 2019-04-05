using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pandora.NetStandard.Core.Identity
{
    public class AccountManagerFacade : AccountManagerFacade<ApplicationUser, ApplicationRole>
    {
        public AccountManagerFacade(
            UserManagerFacade userManager,
            RoleManagerFacade roleManager,
            IHttpContextAccessor contextAccessor,
            IUserClaimsPrincipalFactory<ApplicationUser> claimsFactory,
            IOptions<IdentityOptions> optionsAccessor,
            ILogger<SignInManager<ApplicationUser>> logger,
            IAuthenticationSchemeProvider schemes)
            : base(userManager, roleManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemes)
        {
        }
    }

    public class AccountManagerFacade<TUser, TRole> : SignInManager<TUser> where TUser : ApplicationUser where TRole : ApplicationRole
    {
        public AccountManagerFacade(
            UserManagerFacade<TUser> userManager,
            RoleManagerFacade<TRole> roleManager,
            IHttpContextAccessor contextAccessor,
            IUserClaimsPrincipalFactory<TUser> claimsFactory,
            IOptions<IdentityOptions> optionsAccessor,
            ILogger<SignInManager<TUser>> logger,
            IAuthenticationSchemeProvider schemes)
            : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemes)
        {
            UserManager = userManager;
            RoleManager = roleManager;
        }

        public virtual new UserManagerFacade<TUser> UserManager { get; }
        public virtual RoleManagerFacade<TRole> RoleManager { get; }

        public virtual async Task<IdentityResult> SignUpAsync(TUser user, string pPassword)
        {
            user.PasswordHash = new PasswordHasher<TUser>().HashPassword(user, pPassword);
            return await UserManager.CreateAsync(user);
        }

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

        public virtual async Task<string> GetEmailConfirmTokenAsync(TUser user)
        {
            return await UserManager.GenerateEmailConfirmationTokenAsync(user);
        }

        public virtual async Task<IdentityResult> ConfirmEmailAsync(TUser user, string token)
        {
            return await UserManager.ConfirmEmailAsync(user, token);
        }
    }
}
