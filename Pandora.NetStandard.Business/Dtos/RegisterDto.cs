using System.ComponentModel.DataAnnotations;

namespace Pandora.NetStandard.Business.Dtos
{
    public class RegisterDto : LoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [MaxLength(50), Display(Name = "First Name")]
        public string Firstname { get; set; }
        [MaxLength(50), Display(Name = "Last Name")]
        public string Lastname { get; set; }
        [Required]
        [Compare("Password")]
        public string Confirm { get; set; }
    }    
}
