using Microsoft.EntityFrameworkCore.Storage;
using System.Threading.Tasks;

namespace Pandora.NetStandard.Core.Interfaces
{
    public interface IApplicationUow
    {
        IEfRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IEntity;
        bool Commit();
        Task<bool> CommitAsync();
        IDbContextTransaction StartTransaction();
        Task<IDbContextTransaction> StartTransactionAsync();
    }
}
