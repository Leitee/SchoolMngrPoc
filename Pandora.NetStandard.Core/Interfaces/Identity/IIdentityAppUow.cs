using Pandora.NetStandard.Core.Interfaces.Identity;

namespace Pandora.NetStandard.Core.Interfaces
{
    public interface IIdentityAppUow : IApplicationUow
    {
        IUserRepository Users { get; }
        IRoleRepository Roles { get; }

        T GetIdentityRepo<T>() where T : class;
    }
}
