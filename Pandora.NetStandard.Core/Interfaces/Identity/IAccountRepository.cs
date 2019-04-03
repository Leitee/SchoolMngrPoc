using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace Pandora.NetStandard.Core.Interfaces.Identity
{
    public interface IAccountRepository<TIdentity> 
    {
        Task<IQueryable<TIdentity>> GetAllAsync();

        Task<IdentityResult> CreateAsync(TIdentity identity);

        Task<IdentityResult> DeleteAsync(TIdentity identity);

        Task<IdentityResult> DeleteAsync(int identityId);

        Task<TIdentity> FindByIdAsync(int identityId);

        Task<TIdentity> FindByNameAsync(string identityName);

        Task<IdentityResult> UpdateAsync(TIdentity identity);
    }
}
