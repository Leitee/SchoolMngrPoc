using Microsoft.EntityFrameworkCore.Storage;
using Pandora.NetStandard.Core.Interfaces;
using System;
using System.Threading.Tasks;

namespace Pandora.NetCore.Identity.DataAccess
{
    public class IdentityUow : IApplicationUow
    {
        public bool Commit()
        {
            throw new NotImplementedException();
        }

        public Task<bool> CommitAsync()
        {
            throw new NotImplementedException();
        }

        public IEfRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            throw new NotImplementedException();
        }

        public IDbContextTransaction StartTransaction()
        {
            throw new NotImplementedException();
        }

        public Task<IDbContextTransaction> StartTransactionAsync()
        {
            throw new NotImplementedException();
        }
    }
}
