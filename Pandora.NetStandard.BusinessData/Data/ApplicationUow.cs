using System;
using System.Threading.Tasks;
using Pandora.NetStandard.Core.Interfaces;
using Pandora.NetStandard.Model.Entities;

namespace Pandora.NetStandard.BusinessData.Data
{
    public class ApplicationUow : IApplicationUow
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IRepositoryProvider _repositoryProvider;

        public ApplicationUow(IRepositoryProvider repositoryProvider, 
            ApplicationDbContext context)
        {
            _dbContext = context;

            _repositoryProvider = repositoryProvider;
        }

        // Repositories
        public IRepository<Grade> Grades => GetRepo<Grade>();
        public IRepository<Class> Classes => GetRepo<Class>();

        private IRepository<TEntity> GetRepo<TEntity>() where TEntity : class
        {
            return _repositoryProvider.GetRepositoryByEntity<TEntity>();
        }

        /// <summary>
        /// Save pending changes to the database and return true if there was at least 1 row affected
        /// </summary>
        public bool Commit()
        {
            //System.Diagnostics.Debug.WriteLine("Committed");
            return _dbContext.SaveChanges() > 0;
        }

        /// <summary>
        /// Save pending changes to the database asyncly and return the amount of affected rows
        /// </summary>
        public Task<int> CommitAsync()
        {
            return _dbContext.SaveChangesAsync();
        }

        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext?.Dispose();
            }
        }

        #endregion
    }
}
