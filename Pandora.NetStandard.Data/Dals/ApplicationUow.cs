﻿using Pandora.NetStandard.Core.Interfaces;
using Pandora.NetStandard.Core.Interfaces.Identity;
using Pandora.NetStandard.Core.Bases;
using Pandora.NetStandard.Model.Entities;
using System;
using System.Threading.Tasks;

namespace Pandora.NetStandard.Data.Dals
{
    public abstract class ApplicationUow : IApplicationUow
    {
        private readonly ApplicationDbContext _dbContext;

        public ApplicationUow(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        //Repositories
        public abstract IUserRepository Users { get; }
        public abstract IRoleRepository Roles { get; }
        public abstract IRepository<Grade> Grades { get; }
        public abstract IRepository<Class> Classes { get; }


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
        public override IUserRepository Users => GetRepo<IUserRepository>();
        public override IRoleRepository Roles => GetRepo<IRoleRepository>();
        public override IRepository<Grade> Grades => GetRepoByEntity<Grade>();
        public override IRepository<Class> Classes => GetRepoByEntity<Class>();

        private IRepository<T> GetRepoByEntity<T>() where T : class
        {
            return _repositoryProvider.GetRepositoryForEntityType<T>();
        }

        private T GetRepo<T>() where T : class
        {
            return _repositoryProvider.GetRepository<T>();
        }
    }
}
