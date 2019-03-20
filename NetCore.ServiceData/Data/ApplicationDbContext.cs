using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NetCore.Core.Interfaces;
using NetCore.Core.Security.Identity;
using NetCore.Model.Entities;
using System;

namespace NetCore.ServiceData.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser,ApplicationRole, int>, IApplicationDbContext
    {
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Grade> Grades { get; set; }
        public DbSet<Class> Classes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename = ./schoolDB.db");
            base.OnConfiguring(optionsBuilder);

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            //Rename Identity tables
            builder.Entity<ApplicationUser>().ToTable("Users");
            builder.Entity<ApplicationRole>().ToTable("Roles");
            builder.Entity<IdentityRoleClaim<int>>().ToTable("RoleClaims");
            builder.Entity<IdentityUserClaim<int>>().ToTable("UserClaims");
            builder.Entity<IdentityUserRole<int>>().ToTable("UserRoles").HasKey(key => new { key.UserId, key.RoleId });
            builder.Entity<IdentityUserLogin<int>>().ToTable("UserLogins").HasKey(key => new { key.ProviderKey, key.LoginProvider });
            builder.Entity<IdentityUserToken<int>>().ToTable("UserTokens").HasKey(key => new { key.UserId, key.LoginProvider, key.Name });
        }
    }
}