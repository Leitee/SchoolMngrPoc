using Microsoft.AspNetCore.Identity;
using Pandora.NetStandard.Core.Security.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace Pandora.NetStandard.Core.Interfaces.Identity
{
    public interface IRoleManagerFacade<TRole> where TRole : ApplicationRole
    {
        Task<IQueryable<TRole>> GetAllRolesAsync();

        Task<IdentityResult> CreateAsync(TRole role);

        Task<IdentityResult> DeleteAsync(TRole role);

        Task<IdentityResult> DeleteAsync(int roleId);

        Task<TRole> FindByIdAsync(int roleId);

        Task<TRole> FindByNameAsync(string roleName);

        Task<IdentityResult> UpdateAsync(TRole role);
    }
}
