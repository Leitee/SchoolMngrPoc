using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Pandora.NetStandard.Core.Interfaces
{
    public interface ISQLRepository<TEntity> : IRepository<TEntity>, IPaginableRepository<TEntity>
    {
        Task<TEntity> GetByExpressionAsync(Expression<Func<TEntity, bool>> predicate);

        Task<int> GetCountAsync();

        Task<int> GetCountAsync(Expression<Func<TEntity, bool>> predicate);

        Task<int> ExecuteQueryAsync(string query, params object[] paramaters);

        Task<List<TEntity>> ExecSp(string spName, params object[] parameters);
    }
}
