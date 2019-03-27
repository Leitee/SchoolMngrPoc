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
        IUserRepository UserManager { get; }
        Task<IdentityResult> SignUpAsync<TRole>(TUser user, string pPassword, IEnumerable<TRole> roles) where TRole : ApplicationRole;
        Task<SignInResult> SignInAsync(string pUsername, string pPassword, bool pRememberMe);
        Task SignOutAsync();
    }
}
