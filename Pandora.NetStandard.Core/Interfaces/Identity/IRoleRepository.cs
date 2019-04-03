using Microsoft.AspNetCore.Identity;
using Pandora.NetStandard.Core.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace Pandora.NetStandard.Core.Interfaces.Identity
{
    public interface IRoleRepository : IRoleRepository<ApplicationRole>
    {

    }

    public interface IRoleRepository<TRole> : IAccountRepository<TRole> where TRole : ApplicationRole
    {

    }
}
