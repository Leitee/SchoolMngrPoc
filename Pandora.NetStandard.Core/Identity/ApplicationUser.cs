using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Pandora.NetStandard.Core.Identity
{ 
    public class ApplicationUser : IdentityUser<int>
    {
        public ApplicationUser() { }
        public ApplicationUser(string pUsername, string pEmail, string pFirstName, string pLastName) : base( pUsername )
        {
            Email = pEmail;
            FirstName = pFirstName;
            LastName = pLastName;
            JoinDate = DateTime.UtcNow;
        }

        [Required]
        [MaxLength(100)]
        public virtual string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public virtual string LastName { get; set; }

        public virtual DateTime JoinDate { get; set; }

        public override sealed string PasswordHash { get; set; }

        public override string ToString()
        {
            return $"{base.UserName} - {LastName.ToUpper()} {FirstName}";
        }
    }
}
