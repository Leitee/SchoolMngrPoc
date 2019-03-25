namespace Pandora.NetStandard.Core.Config
{
    public class AppSettings
    {
        public string ConnectionString { get; set; }
        public string JwtSecretKey { get; set; }
        public string JwtValidIssuer { get; set; }
        public string JwtValidAudience { get; set; }
    }
}
