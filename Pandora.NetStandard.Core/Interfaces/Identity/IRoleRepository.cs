using Pandora.NetStandard.Core.Identity;

namespace Pandora.NetStandard.Core.Interfaces.Identity
{
    public interface IRoleRepository : IRoleRepository<ApplicationRole>
    {

    }

    public interface IRoleRepository<TRole> : IAccountRepository<TRole> where TRole : ApplicationRole
    {

    }
}
