using System.Linq;

namespace NetCore.Core.Bases
{
    public class PagedResult<TEntity> where TEntity : class
    {
        public int CurrentPage { get; set; }

        public int RowsPerPage { get; set; }

        public int CollectionLength { get; set; }

        public double TotalPages { get; set; }

        public IQueryable<TEntity> Collection { get; set; }
    }
}
