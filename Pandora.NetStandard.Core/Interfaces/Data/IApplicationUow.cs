using Pandora.NetStandard.Core.Interfaces.Identity;
using System;
using System.Threading.Tasks;

namespace Pandora.NetStandard.Core.Interfaces
{
    public interface IApplicationUow : IDisposable
    {
        IUserRepository Users { get; }
        IRoleRepository Roles { get; }
        bool Commit();
        Task<bool> CommitAsync();
    }
}
