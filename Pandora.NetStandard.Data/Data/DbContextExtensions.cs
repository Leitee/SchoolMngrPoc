using Microsoft.AspNetCore.Identity;
using Pandora.NetStandard.Core.Identity;
using Pandora.NetStandard.Core.Security.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pandora.NetStandard.Data.Data
{
    public static class DbContextExtensions
    {
        public static void Seed(this ApplicationDbContext pDbContext)
        {
            // Add entities for DbContext instance
            pDbContext.Users.Add(new ApplicationUser
            {
                UserName = "DevAdmin",
                PasswordHash = "devadmin321",
                Email = "lm23moreno@gmail.com",
                EmailConfirmed = true,
                FirstName = "Leonardo",
                LastName = "Moreno",
                JoinDate = DateTime.Now
            });

            pDbContext.Roles.Add(new ApplicationRole
            {
                Name = "Dev",
                Description = "All features available for this role."
            });

            pDbContext.SaveChanges();
        }
    }
}
