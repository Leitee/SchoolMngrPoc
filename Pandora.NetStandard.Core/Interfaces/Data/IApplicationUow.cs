using Pandora.NetStandard.Core.Interfaces.Identity;
using System;
using System.Threading.Tasks;

namespace Pandora.NetStandard.Core.Interfaces
{
    public interface IApplicationUow
    {
        IUserRepository Users { get; }
        IRoleRepository Roles { get; }
        IRepository<TEntity> GetRepo<TEntity>() where TEntity : class;
        bool Commit();
        Task<bool> CommitAsync();
    }
}
