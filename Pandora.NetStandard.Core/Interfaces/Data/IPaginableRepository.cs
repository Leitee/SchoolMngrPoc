using Pandora.NetStandard.Core.Interfaces.Data;
using Pandora.NetStandard.Core.Utils;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Pandora.NetStandard.Core.Interfaces
{
    public interface IPaginableRepository<TEntity> where TEntity : class
    {
        Task<BLPagedResponse<TEntity>> AllPagedAsync(int skip, int take, int pageSize, int currentPage,
            Expression<Func<TEntity, bool>> predicate,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
            params Expression<Func<IIncludable<TEntity>, IIncludable>>[] includes);
    }
}
