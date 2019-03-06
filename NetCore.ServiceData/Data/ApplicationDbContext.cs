using Microsoft.EntityFrameworkCore;
using NetCore.Core.Interfaces;
using NetCore.Model.Entities;

namespace NetCore.ServiceData.Data
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Class> Classes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = schoolDB.db");
        }
    }
}