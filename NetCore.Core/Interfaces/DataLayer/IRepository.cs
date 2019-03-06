using NetCore.Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NetCore.Core.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<PagedResult<TEntity>> AllPagedAsync(int skip, int take, int pageSize, int currentPage,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
            Expression<Func<TEntity, bool>> predicate,
            params Expression<Func<TEntity, object>>[] includes);

        Task<IQueryable<TEntity>> AllAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>,
            IOrderedQueryable<TEntity>> orderBy, params Expression<Func<TEntity, object>>[] includes);

        Task<TEntity> GetByIdAsync(object id);

        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate,
            params Expression<Func<TEntity, object>>[] includes);

        Task<TEntity> GetByExpressionAsync(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> InsertAsync(TEntity entity);

        Task UpdateAsync(TEntity entityToUpdate);

        Task DeleteAsync(object id);

        Task DeleteAsync(TEntity entityToDelete);

        Task<int> GetCountAsync();

        Task<int> GetCountAsync(Expression<Func<TEntity, bool>> predicate);

        Task<int> ExecuteQueryAsync(string query, params object[] paramaters);

        Task<List<TEntity>> ExecSp(string spName, params object[] parameters);
    }
}
