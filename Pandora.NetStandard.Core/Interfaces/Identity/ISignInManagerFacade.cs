using Microsoft.AspNetCore.Identity;
using Pandora.NetStandard.Core.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pandora.NetStandard.Core.Interfaces.Identity
{
    public interface ISignInManagerFacade : ISignInManagerFacade<ApplicationUser>
    {

    }

    public interface ISignInManagerFacade<TUser> where TUser : ApplicationUser
    {
        //IUserRepository<TUser> UserManager { get; }
        Task<IdentityResult> SignUpAsync<TRole>(TUser user, string pPassword, IEnumerable<TRole> roles) where TRole : ApplicationRole;
        Task<SignInResult> SignInAsync(string pUsername, string pPassword, bool pRememberMe);
        Task SignOutAsync();
        Task<string> GetEmailConfirmTokenAsync(TUser user);
        Task<bool> SendEmailAsync(string pEmail, string pUrlRedirect);
        Task<bool> ConfirmEmailAsync(TUser user, string token);
    }
}
