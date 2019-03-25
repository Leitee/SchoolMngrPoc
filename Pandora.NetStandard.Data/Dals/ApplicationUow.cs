using Pandora.NetStandard.Core.Interfaces;
using Pandora.NetStandard.Model.Entities;
using System;
using System.Threading.Tasks;

namespace Pandora.NetStandard.Data.Dals
{
    public class ApplicationUow : IApplicationUow
    {
        private readonly SchoolDbContext _dbContext;
        private readonly IRepositoryProvider<SchoolDbContext> _repositoryProvider;

        public ApplicationUow(IRepositoryProvider<SchoolDbContext> repositoryProvider)
        {
            _repositoryProvider = repositoryProvider;
            _dbContext = _repositoryProvider.DbContext;
        }

        // Repositories
        public IRepository<Grade> Grades => GetRepoByEntity<Grade>();
        public IRepository<Class> Classes => GetRepoByEntity<Class>();

        private IRepository<T> GetRepoByEntity<T>() where T : class
        {
            return _repositoryProvider.GetRepositoryForEntityType<T>();
        }

        private T GetRepo<T>() where T : class
        {
            return _repositoryProvider.GetRepository<T>();
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
        public async Task<bool> CommitAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }

        #region IDisposable

        private bool disposed = false;

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
            disposed = true;
        }

        #endregion
    }
}
