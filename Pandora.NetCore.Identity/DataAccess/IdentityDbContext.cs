using Microsoft.EntityFrameworkCore;
using Pandora.NetStdLibrary.Base.Base;

namespace Pandora.NetCore.Identity
{
    public class IdentityDbContext : ApplicationDbContext
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options)
        {

        }
    }
}
