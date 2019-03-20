namespace Pandora.NetStandard.BusinessData.Dtos
{
    public class RegisterDto : LoginDto
    {
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Secondname { get; set; }
    }
}
