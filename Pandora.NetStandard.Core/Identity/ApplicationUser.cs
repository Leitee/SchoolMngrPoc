using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Pandora.NetStandard.Core.Security.Identity
{
    public class ApplicationUser : IdentityUser<int>
    {
        public ApplicationUser() { }
        public ApplicationUser(string pUsername, string pEmail, string pFirstName, string pLastName) : base( pUsername )
        {
            Email = pEmail;
            FirstName = pFirstName;
            LastName = pLastName;
            JoinDate = DateTime.Now;
        }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        public DateTime JoinDate { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
