using Microsoft.EntityFrameworkCore;
using NetCore.Model.Entities;
using System;

namespace NetCore.ServiceData
{
    public class SchoolContext : DbContext
    {
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Class> Classes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = schoolDB.db");
        }
    }
}
