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
        public UnitTestDbContext(IConfiguration config, DbContextOptions options) : base(config, options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseInMemoryDatabase("TestDB");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
