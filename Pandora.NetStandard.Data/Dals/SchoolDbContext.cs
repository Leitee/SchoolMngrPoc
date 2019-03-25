using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pandora.NetStandard.Core.Repository;
using Pandora.NetStandard.Model.Entities;

namespace Pandora.NetStandard.Data.Dals
{
    public class SchoolDbContext : ApplicationDbContext
    {
        public SchoolDbContext(IConfiguration config, DbContextOptions<SchoolDbContext> options) : base(config, options)
        {
        }

        public DbSet<Grade> Grades { get; set; }
        public DbSet<Class> Classes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseSqlite("Filename = ./schoolDB.db");

            optionsBuilder.UseSqlServer(_config["AppSettings:ConnectionString"], options =>
            {
                options.MigrationsHistoryTable("Migrations", "Config");
            });
        }
    }
}