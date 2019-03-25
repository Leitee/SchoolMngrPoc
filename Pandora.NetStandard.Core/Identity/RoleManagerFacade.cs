using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Pandora.NetStandard.Core.Interfaces.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pandora.NetStandard.Core.Identity
{
    public class RoleManagerFacade<TRole> : RoleManager<TRole>, IRoleManagerFacade<TRole> where TRole : ApplicationRole
    {
        public RoleManagerFacade(IRoleStore<TRole> store, IEnumerable<IRoleValidator<TRole>> roleValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, ILogger<RoleManager<TRole>> logger) : base(store, roleValidators, keyNormalizer, errors, logger)
        {
        }

        public virtual async Task<IdentityResult> DeleteAsync(int roleId)
        {
            TRole role = await FindByIdAsync(roleId);
            return await DeleteAsync(role);
        }

        public virtual async Task<TRole> FindByIdAsync(int roleId)
        {
            return await FindByIdAsync(roleId.ToString());
        }

        public virtual async Task<IQueryable<TRole>> GetAllRolesAsync()
        {
            return await Task.Run(() =>
            {
                return Roles;
            });
        }
    }
}
