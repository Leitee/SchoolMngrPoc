namespace Pandora.NetStandard.Business.Dtos
{
    public class RegisterDto : LoginDto
    {
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }    
}
