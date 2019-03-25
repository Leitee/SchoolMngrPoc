using Microsoft.AspNetCore.Identity;
using Pandora.NetStandard.Core.Identity;
using System.Threading.Tasks;

namespace Pandora.NetStandard.Core.Interfaces.Identity
{
    public interface ISignInManagerFacade<TUser> where TUser : ApplicationUser
    {
        Task<IdentityResult> SignUpAsync(TUser user, string pPassword);
        Task<SignInResult> SignInAsync(string pUsername, string pPassword, bool pRememberMe);
        Task SignOutAsync();
    }
}
