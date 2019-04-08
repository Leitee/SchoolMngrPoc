using System.ComponentModel.DataAnnotations;

namespace Pandora.NetStandard.Business.Dtos
{
    public class LoginDto
    {
        [Required]
        [Display(Name = "User Name"), MinLength(6)]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password), MinLength(6)]
        public string Password { get; set; }
        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
