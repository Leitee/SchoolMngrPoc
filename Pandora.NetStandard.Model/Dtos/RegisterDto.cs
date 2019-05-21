using Reinforced.Typings.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Pandora.NetStandard.Model.Dtos
{
    [TsInterface(AutoI = false, Name = "Register")]
    public sealed class RegisterDto : LoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(50), Display(Name = "First Name")]
        public string FirstName { get; set; }

        [MaxLength(50), Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Compare("Password")]
        public string Confirm { get; set; }
    }
}
