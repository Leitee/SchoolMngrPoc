namespace NetCore.ServiceData.Dtos
{
    public class RegisterDto : LoginDto
    {
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Secondname { get; set; }
    }
}
