using Microsoft.AspNetCore.Identity;
using Pandora.NetStandard.Core.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pandora.NetStandard.Core.Interfaces.Identity
{
    public interface IUserRepository : IUserRepository<ApplicationUser>
    {

    }

    public interface IUserRepository<TUser> where TUser : ApplicationUser
    {
        Task<IQueryable<TUser>> GetAllUsersAsync();

        Task<IdentityResult> CreateAsync(TUser user);

        Task<IdentityResult> CreateAsync<TRole>(TUser user, IEnumerable<TRole> roles) where TRole : ApplicationRole;

        Task<IdentityResult> DeleteAsync(TUser user);

        Task<IdentityResult> DeleteAsync(int roleId);

        Task<TUser> FindByIdAsync(int userId);

        Task<TUser> FindByNameAsync(string userName);

        Task<IdentityResult> UpdateAsync(TUser user);
    }
}
