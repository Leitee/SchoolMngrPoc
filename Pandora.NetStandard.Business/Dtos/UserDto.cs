using Pandora.NetStandard.Core.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Pandora.NetStandard.Business.Dtos
{
    public class UserDto : ApplicationUser
    {
        public UserDto()
        {
        }
        public UserDto(string pUsername, string pEmail, string pFirstName, string pLastName) 
            : base(pUsername, pEmail, pFirstName, pLastName)
        {
        }

        public override int Id { get; set; }
        [Display(Name = "User Name")]
        public override string UserName { get; set; }
        public override string Email { get; set; }
        [Display(Name = "Phone Number")]
        public override string PhoneNumber { get; set; }
        [Display(Name = "First Name")]
        public override string FirstName { get; set; }
        [Display(Name = "Second Name")]
        public override string LastName { get; set; }
        [Display(Name = "Join Date")]
        public override DateTime JoinDate { get { return base.JoinDate; } }
        public string PasswordHash { set => base.PasswordHash = value; }
    }
}
