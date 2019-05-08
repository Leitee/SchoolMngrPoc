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
            NormalizedUserName = UserName.ToUpper();
            NormalizedEmail = Email.ToUpper();
        }

        [Required]
        [MaxLength(100)]
        public virtual string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public virtual string LastName { get; set; }

        public virtual DateTime JoinDate { get; set; }

        public virtual string FullName { get { return $"{LastName.ToUpper()} {FirstName}"; } }

        public override string ToString()
        {
            return $"{UserName} - {FullName}";
        }
    }
}
