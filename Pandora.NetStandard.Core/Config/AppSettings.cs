namespace Pandora.NetStandard.Core.Config
{
    public class AppSettings
    {
        public string ConnectionString { get; set; }
        public string JwtSecretKey { get; set; }
        public string JwtValidIssuer { get; set; }
        public string JwtValidAudience { get; set; }
        public string MailFrom { get; set; }
        public string MailServer { get; set; }
        public int MailPort { get; set; }
        public string MailPassword { get; set; }
    }
}
