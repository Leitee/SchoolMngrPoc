using Pandora.NetStandard.Core.Identity;
using Pandora.NetStandard.Core.Security;

namespace Pandora.NetStandard.Core.Interfaces
{
    public interface IJwtTokenProvider
    {
        TokenResponse GenerateToken<TUser, TRole>(TUser pUser, TRole pRole) where TUser : ApplicationUser where TRole : ApplicationRole;
    }
}
