using Pandora.NetStandard.Core.Bases;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Pandora.NetStandard.Core.Interfaces
{
    public interface IPaginableRepository<TEntity> where TEntity : class
    {
        Task<BLPagedResponse<TEntity>> AllPagedAsync(int skip, int take, int pageSize, int currentPage,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
            Expression<Func<TEntity, bool>> predicate,
            params Expression<Func<TEntity, object>>[] includes);
    }
}
