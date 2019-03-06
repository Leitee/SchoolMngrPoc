using NetCore.Core.Interfaces;
using System;

namespace NetCore.ServiceData.Data
{
    public class RepositoryProvider : IRepositoryProvider
    {
        public IApplicationDbContext DbContext { get; set; }

        public T GetRepository<T>(Func<IApplicationDbContext, object> factory = null) where T : class
        {
            throw new NotImplementedException();
        }

        public IRepository<T> GetRepositoryByEntity<T>() where T : class
        {
            return GetRepository<IRepository<T>>(
                GetRepositoryFactoryForEntityType<T>());
        }

        public void SetRepository<T>(T repository)
        {
            throw new NotImplementedException();
        }

        protected virtual Func<IApplicationDbContext, object> GetRepositoryFactoryForEntityType<T>() where T : class
        {
            return dbContext => new SQLiteRepository<T>(dbContext);
        }
    }
}
