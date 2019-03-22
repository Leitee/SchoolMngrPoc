using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Pandora.NetStandard.Core.Interfaces
{
    public interface IRepository
    {
        Task<IQueryable<TEntity>> AllAsync<TEntity>(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>,
            IOrderedQueryable<TEntity>> orderBy, params Expression<Func<TEntity, object>>[] includes);

        Task<TEntity> GetByIdAsync<TEntity>(object id);

        Task<TEntity> FindAsync<TEntity>(Expression<Func<TEntity, bool>> predicate,
            params Expression<Func<TEntity, object>>[] includes);

        Task<TEntity> InsertAsync<TEntity>(TEntity entity);

        Task UpdateAsync<TEntity>(TEntity entityToUpdate);

        Task DeleteAsync<TEntity>(object id);

        Task DeleteAsync<TEntity>(TEntity entityToDelete);
    }

    public interface IRepository<TEntity>
    {
        Task<IQueryable<TEntity>> AllAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>,
            IOrderedQueryable<TEntity>> orderBy, params Expression<Func<TEntity, object>>[] includes);

        Task<TEntity> GetByIdAsync(object id);

        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate,
            params Expression<Func<TEntity, object>>[] includes);

        Task<TEntity> InsertAsync(TEntity entity);

        Task UpdateAsync(TEntity entityToUpdate);

        Task DeleteAsync(object id);

        Task DeleteAsync(TEntity entityToDelete);
    }
}
