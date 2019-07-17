using System.Threading.Tasks;

namespace Pandora.NetStandard.Core.Interfaces
{
    public interface IApplicationUow
    {
        IRepository<TEntity> GetRepo<TEntity>() where TEntity : class;
        bool Commit();
        Task<bool> CommitAsync();
    }
}
