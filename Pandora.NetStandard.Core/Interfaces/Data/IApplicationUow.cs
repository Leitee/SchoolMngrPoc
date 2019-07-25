using Microsoft.EntityFrameworkCore.Storage;
using System.Threading.Tasks;

namespace Pandora.NetStandard.Core.Interfaces
{
    public interface IApplicationUow
    {
        IEfRepository<TEntity> GetRepo<TEntity>() where TEntity : class;
        bool Commit();
        Task<bool> CommitAsync();
        IDbContextTransaction StartTransaction();
        Task<IDbContextTransaction> StartTransactionAsync();
    }
}
