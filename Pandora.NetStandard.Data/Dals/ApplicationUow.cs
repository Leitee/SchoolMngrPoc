using Microsoft.EntityFrameworkCore.Storage;
using Pandora.NetStandard.Core.Base;
using Pandora.NetStandard.Core.Interfaces;
using Pandora.NetStandard.Core.Interfaces.Identity;
using System;
using System.Threading.Tasks;

namespace Pandora.NetStandard.Data.Dals
{
    public abstract class ApplicationUow : IIdentityAppUow, IDisposable
    {
        private readonly ApplicationDbContext _dbContext;

        public ApplicationUow(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Repositories
        public abstract IUserRepository Users { get; }
        public abstract IRoleRepository Roles { get; }

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

        /// <summary>
        /// For transaction handling
        /// </summary>
        /// <returns></returns>
        public IDbContextTransaction StartTransaction()
        {
            return _dbContext.Database.BeginTransaction();
        }

        /// <summary>
        /// For transaction handling asyncly
        /// </summary>
        /// <returns></returns>
        public async Task<IDbContextTransaction> StartTransactionAsync()
        {
            return await _dbContext.Database.BeginTransactionAsync();
        }

        #region IDisposable
        //TODO: see Dispose pattern
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

        public abstract IEfRepository<T> GetRepository<T>() where T : class, IEntity;

        //protected abstract T GetIdentityRepo<T>();

        public abstract T GetIdentityRepo<T>() where T : class;
    }

    public class ApplicationUow<TContext> : ApplicationUow where TContext : ApplicationDbContext
    {
        private readonly IRepositoryProvider<TContext> _repositoryProvider;

        public ApplicationUow(TContext context, IRepositoryProvider<TContext> repositoryProvider)
            : base(context)
        {
            _repositoryProvider = repositoryProvider;
        }

        // Repositories
        public override IUserRepository Users => GetIdentityRepo<IUserRepository>();
        public override IRoleRepository Roles => GetIdentityRepo<IRoleRepository>();

        public override IEfRepository<T> GetRepository<T>()
        {
            return _repositoryProvider.GetRepositoryForEntityType<T>();
        }

        public override T GetIdentityRepo<T>()
        {
            return _repositoryProvider.GetRepository<T>();
        }
    }
}
