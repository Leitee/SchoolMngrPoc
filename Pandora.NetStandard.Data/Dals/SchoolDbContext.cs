using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pandora.NetStandard.Core.Identity;
using Pandora.NetStandard.Core.Repository;
using Pandora.NetStandard.Core.Utils;
using Pandora.NetStandard.Model.Entities;
using Pandora.NetStandard.Model.Enums;
using System;
using System.Collections.Generic;

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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region Identity fields seeding
            builder.Entity<ApplicationRole>().HasData(new List<ApplicationRole>
            {
                new ApplicationRole(RolesEnum.DEBUG.GetDescription(), "Full functionality over app and debugin") { Id = RolesEnum.DEBUG.GetId() },
                new ApplicationRole(RolesEnum.ADMINISTRADOR.GetDescription(), "Full permissions and features") { Id = RolesEnum.ADMINISTRADOR.GetId() },
                new ApplicationRole(RolesEnum.SUPERVISOR.GetDescription(), "Limited functionality just administrative permissions") { Id = RolesEnum.SUPERVISOR.GetId() },
                new ApplicationRole(RolesEnum.TEACHER.GetDescription(), "Limited functionality just teaching-relative permissions") { Id = RolesEnum.TEACHER.GetId() }
            });

            builder.Entity<ApplicationUser>().HasData(new ApplicationUser("devadmin", "info@pandorasistemas.com", "Jhon", "Doe")
            {
                Id = -1,
                EmailConfirmed = true,
                LockoutEnabled = false,
                TwoFactorEnabled = false,
                PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "Dev321"),
                SecurityStamp = string.Empty,
            });

            builder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int>() { UserId = -1, RoleId = -1 });
            #endregion

            builder.Entity<Grade>().HasData(
                new Grade { Id = 1, Name = "1ro" },
                new Grade { Id = 2, Name = "2do" },
                new Grade { Id = 3, Name = "3ro" }
                );

            builder.Entity<Class>().HasData(
                new Class { Id = 1, Name = "1ra", Shift = ShiftTimeEnum.TOMORROW, GradeId = 1 },
                new Class { Id = 2, Name = "2da", Shift = ShiftTimeEnum.AFTERNOON, GradeId = 1 },
                new Class { Id = 3, Name = "3ra", Shift = ShiftTimeEnum.NIGHT, GradeId = 1 },
                new Class { Id = 4, Name = "1ra", Shift = ShiftTimeEnum.TOMORROW, GradeId = 2 },
                new Class { Id = 5, Name = "2da", Shift = ShiftTimeEnum.AFTERNOON, GradeId = 2 },
                new Class { Id = 6, Name = "1ra", Shift = ShiftTimeEnum.NIGHT, GradeId = 3 }
                );
        }
    }
}