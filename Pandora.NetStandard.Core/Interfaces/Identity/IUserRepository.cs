using Microsoft.AspNetCore.Identity;
using Pandora.NetStandard.Core.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace Pandora.NetStandard.Core.Interfaces.Identity
{
    public interface IUserRepository : IUserRepository<ApplicationUser>
    {

    }

    public interface IUserRepository<TRole> where TRole : ApplicationUser
    {
        Task<IQueryable<TRole>> GetAllUsersAsync();

        Task<IdentityResult> CreateAsync(TRole role);

        Task<IdentityResult> DeleteAsync(TRole role);

        Task<IdentityResult> DeleteAsync(int roleId);

        Task<TRole> FindByIdAsync(int roleId);

        Task<TRole> FindByNameAsync(string roleName);

        Task<IdentityResult> UpdateAsync(TRole role);
    }
}
