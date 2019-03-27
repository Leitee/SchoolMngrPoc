using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pandora.NetStandard.Data.Dals;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pandora.NetCore.UnitTest
{
    public class UnitTestDbContext : SchoolDbContext
    {
        public UnitTestDbContext(IConfiguration config, DbContextOptions<SchoolDbContext> options) : base(config, options)
        {
            // Create options for DbContext instance
            options = new DbContextOptionsBuilder<SchoolDbContext>()
                .UseInMemoryDatabase("Test")
                .Options;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
        }
    }
}
