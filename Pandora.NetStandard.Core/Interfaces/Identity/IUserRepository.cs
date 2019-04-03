using Pandora.NetStandard.Core.Identity;

namespace Pandora.NetStandard.Core.Interfaces.Identity
{
    public interface IUserRepository : IUserRepository<ApplicationUser>
    {

    }

    public interface IUserRepository<TUser> : IAccountRepository<TUser> where TUser : ApplicationUser
    {

    }
}
