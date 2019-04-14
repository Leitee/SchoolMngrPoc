using Microsoft.EntityFrameworkCore;
using Pandora.NetStandard.Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pandora.NetCore.Identity
{
    public class IdentityDbContext : ApplicationDbContext
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options)
        {

        }
    }
}
