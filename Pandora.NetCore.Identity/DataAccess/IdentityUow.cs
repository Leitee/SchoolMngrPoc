using Pandora.NetStandard.Core.Interfaces;
using Pandora.NetStandard.Core.Interfaces.Identity;
using System;
using System.Threading.Tasks;

namespace Pandora.NetCore.Identity.DataAccess
{
    public class IdentityUow : IApplicationUow
    {
        public IUserRepository Users => throw new NotImplementedException();

        public IRoleRepository Roles => throw new NotImplementedException();

        public bool Commit()
        {
            throw new NotImplementedException();
        }

        public Task<bool> CommitAsync()
        {
            throw new NotImplementedException();
        }

        public IRepository<TEntity> GetRepo<TEntity>() where TEntity : class
        {
            throw new NotImplementedException();
        }
    }
}
