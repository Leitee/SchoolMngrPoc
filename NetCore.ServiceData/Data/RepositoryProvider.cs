﻿using NetCore.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace NetCore.ServiceData.Data
{
    public class RepositoryProvider : IRepositoryProvider
    {
        /// <summary>
        /// Get and set the <see cref="DbContext"/> with which to initialize a repository
        /// if one must be created.
        /// </summary>
        public IApplicationDbContext DbContext { get; set; }

        /// <summary>
        /// Get the dictionary of repository objects, keyed by repository type.
        /// </summary>
        /// <remarks>
        /// Caller must know how to cast the repository object to a useful type.
        /// <p>This is an extension point. You can register fully made repositories here
        /// and they will be used instead of the ones this provider would otherwise create.</p>
        /// </remarks>
        protected Dictionary<Type, object> Repositories { get; private set; }

        public T GetRepository<T>(Func<IApplicationDbContext, object> factory = null) where T : class
        {
            // Look for T dictionary cache under typeof(T).
            Repositories.TryGetValue(typeof(T), out object repoObj);
            if (repoObj != null)
            {
                return (T)repoObj;
            }

            // Not found or null; make one, add to dictionary cache, and return it.
            return MakeRepository<T>(factory, DbContext);
        }

        public IRepository<T> GetRepositoryByEntity<T>() where T : class
        {
            return GetRepository<IRepository<T>>(
                GetRepositoryForEntityType<T>());
        }

        protected virtual T MakeRepository<T>(Func<ApplicationDbContext, object> factory, IApplicationDbContext dbContext)
        {
            if (factory == null)
            {
                throw new ApplicationException("No factory for repository type, " + typeof(T).FullName);
            }
            var repo = (T)factory((ApplicationDbContext)dbContext);
            SetRepository(repo);
            return repo;
        }

        public void SetRepository<T>(T repository)
        {
            Repositories[typeof(T)] = repository;
        }

        protected virtual Func<IApplicationDbContext, object> GetRepositoryForEntityType<T>() where T : class
        {
            return dbContext => new SQLiteRepository<T>(dbContext);
        }
    }
}
