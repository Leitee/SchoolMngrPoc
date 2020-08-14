using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pandora.NetStdLibrary.Base.Base;
using Pandora.NetStdLibrary.Base.Config;
using Pandora.NetStdLibrary.Base.Identity;
using Pandora.NetStdLibrary.Base.Utils;
using Pandora.NetStandard.Model.Entities;
using Pandora.NetStandard.Model.Enums;
using System;
using System.Collections.Generic;

namespace Pandora.NetStandard.Data.Dals
{
    public class SchoolDbContext : ApplicationDbContext
    {
        protected readonly AppSettings _appSettings;//TODO: to see...

        public SchoolDbContext(IConfiguration config, DbContextOptions options, bool isTestInstance = false) : base(options)
        {
            if (!isTestInstance)
                _appSettings = AppSettings.GetSettings(config ?? throw new ArgumentNullException(nameof(config)));
            //_appSettings.ConnectionString = $"Server={config["SQLSERVER_NAME"]};Database=SchoolMngr;User=sa;Password=Devadmin321;";
        }

        public DbSet<Grade> Grades { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Attend> Attends { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //If you want to apply and avoid to include each entity manually
            //optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
            optionsBuilder.EnableDetailedErrors(!_appSettings.IsProdMode);
            optionsBuilder.EnableSensitiveDataLogging(!_appSettings.IsProdMode);
            //optionsBuilder.UseSqlite("Filename = ./schoolDB.db");//Enable for sqlite using
            optionsBuilder.UseSqlServer(_appSettings.ConnectionString, options =>
            {
                options.MigrationsHistoryTable("Migrations", "EFConfig");
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
                new ApplicationRole(RolesEnum.TEACHER.GetDescription(), "Limited functionality just teaching-relative permissions") { Id = RolesEnum.TEACHER.GetId() },
                new ApplicationRole(RolesEnum.STUDENT.GetDescription(), "Limited functionality just student-relative permissions") { Id = RolesEnum.STUDENT.GetId() }
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

            builder.Entity<ApplicationUser>().HasData(new ApplicationUser("risanchez", "risanchez@admin.com", "Rick", "Sanchez")
            {
                Id = 1,
                EmailConfirmed = true,
                LockoutEnabled = false,
                TwoFactorEnabled = false,
                PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "Rick321"),
                SecurityStamp = string.Empty,
            });

            builder.Entity<ApplicationUser>().HasData(new ApplicationUser("dabrown", "dabrown@teacher.com", "Dan", "Brown")
            {
                Id = 11,
                EmailConfirmed = true,
                LockoutEnabled = false,
                TwoFactorEnabled = false,
                PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "Dan321"),
                SecurityStamp = string.Empty,
            });

            builder.Entity<ApplicationUser>().HasData(new ApplicationUser("brwayne", "bruce.wayne@student.com", "Bruce", "Wayne")
            {
                Id = 101,
                EmailConfirmed = true,
                LockoutEnabled = false,
                TwoFactorEnabled = false,
                PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "Bru321"),
                SecurityStamp = string.Empty,
            });

            builder.Entity<ApplicationUser>().HasData(new ApplicationUser("anrand", "ayn.rand@student.com", "Ayn", "Rand")
            {
                Id = 102,
                EmailConfirmed = true,
                LockoutEnabled = false,
                TwoFactorEnabled = false,
                PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "Ayn321"),
                SecurityStamp = string.Empty,
            });

            builder.Entity<ApplicationUser>().HasData(new ApplicationUser("mifriedman", "milton.friedman@student.com", "Milton", "Fiedman")
            {
                Id = 103,
                EmailConfirmed = true,
                LockoutEnabled = false,
                TwoFactorEnabled = false,
                PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "Mil321"),
                SecurityStamp = string.Empty,
            });

            builder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int>() { UserId = -1, RoleId = RolesEnum.DEBUG.GetId() });
            builder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int>() { UserId = 1, RoleId = RolesEnum.ADMINISTRADOR.GetId() });
            builder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int>() { UserId = 11, RoleId = RolesEnum.TEACHER.GetId() });
            builder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int>() { UserId = 101, RoleId = RolesEnum.STUDENT.GetId() });
            builder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int>() { UserId = 102, RoleId = RolesEnum.STUDENT.GetId() });
            builder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int>() { UserId = 103, RoleId = RolesEnum.STUDENT.GetId() });

            #endregion

            builder.Entity<Grade>().HasData(
                new Grade { Id = 1, Name = "1er" },
                new Grade { Id = 2, Name = "2do" },
                new Grade { Id = 3, Name = "3ro" },
                new Grade { Id = 4, Name = "4to" },
                new Grade { Id = 5, Name = "5to" }
                );

            builder.Entity<Class>().HasData(
                new Class { Id = 1, Name = "1ra", Shift = ShiftTimeEnum.TOMORROW, GradeId = 1 },
                new Class { Id = 2, Name = "2da", Shift = ShiftTimeEnum.AFTERNOON, GradeId = 1 },
                new Class { Id = 3, Name = "1ra", Shift = ShiftTimeEnum.TOMORROW, GradeId = 2 },
                new Class { Id = 4, Name = "2da", Shift = ShiftTimeEnum.NIGHT, GradeId = 2 },
                new Class { Id = 5, Name = "1ra", Shift = ShiftTimeEnum.AFTERNOON, GradeId = 3 },
                new Class { Id = 6, Name = "2da", Shift = ShiftTimeEnum.NIGHT, GradeId = 3 },
                new Class { Id = 7, Name = "1ra", Shift = ShiftTimeEnum.TOMORROW, GradeId = 4 },
                new Class { Id = 8, Name = "1ra", Shift = ShiftTimeEnum.TOMORROW, GradeId = 5 }
                );

            builder.Entity<Subject>().HasData(
                new Subject { Id = 1, Name = "Matemáticas" },
                new Subject { Id = 2, Name = "Fisica" },
                new Subject { Id = 3, Name = "Redes" },
                new Subject { Id = 4, Name = "Algoritmos" },
                new Subject { Id = 5, Name = "Programación", SubjectId = 4 }
                );

            builder.Entity<Teacher>().HasData(
                new Teacher { Id = 32165498, ApplicationUserId = 11 }
                );

            builder.Entity<Student>().HasData(
                new Student { Id = 11111111, ApplicationUserId = 101 },
                new Student { Id = 22222222, ApplicationUserId = 102 },
                new Student { Id = 33333333, ApplicationUserId = 103 }
                );
        }
    }
}