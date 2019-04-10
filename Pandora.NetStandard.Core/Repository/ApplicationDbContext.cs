using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pandora.NetStandard.Core.Identity;
using System;

namespace Pandora.NetStandard.Core.Repository
{
    public abstract class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>, IDisposable
    {
        protected const string SCHEMA_NAME = "Auth";
        protected readonly IConfiguration _config;//TODO: to see...

        public ApplicationDbContext(IConfiguration config, DbContextOptions options) : base(options)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            //Rename Identity tables
            builder.Entity<ApplicationUser>().ToTable("Users", SCHEMA_NAME);
            builder.Entity<ApplicationRole>().ToTable("Roles", SCHEMA_NAME);
            builder.Entity<IdentityRoleClaim<int>>().ToTable("RoleClaims", SCHEMA_NAME);
            builder.Entity<IdentityUserClaim<int>>().ToTable("UserClaims", SCHEMA_NAME);
            builder.Entity<IdentityUserRole<int>>().ToTable("UserRoles", SCHEMA_NAME).HasKey(key => new { key.UserId, key.RoleId });
            builder.Entity<IdentityUserLogin<int>>().ToTable("UserLogins", SCHEMA_NAME).HasKey(key => new { key.ProviderKey, key.LoginProvider });
            builder.Entity<IdentityUserToken<int>>().ToTable("UserTokens", SCHEMA_NAME).HasKey(key => new { key.UserId, key.LoginProvider, key.Name });
        }
    }
}
