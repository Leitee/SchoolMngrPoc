using Microsoft.EntityFrameworkCore;
using Pandora.NetStandard.Core.Util;

namespace Pandora.NetCore.Identity
{
    public class IdentityDbContext : ApplicationDbContext
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options)
        {

        }
    }
}
