using Microsoft.Extensions.Configuration;

namespace Pandora.NetStandard.Core.Config
{
    public class AppSettings
    {
        public string Environment { get; set; }
        public bool IsProdMode { get { return Environment == "Prod"; } }
        public string ConnectionString { get; set; }
        public string JwtSecretKey { get; set; }
        public string JwtValidIssuer { get; set; }
        public string JwtValidAudience { get; set; }
        public string SendGridUser { get; set; }
        public string SendGridApiKey { get; set; }
        public string SendGridUserSender { get; set; }
        public string SendGridSubject { get; set; }
        public string SendGridFrom { get; set; }
        public string ElasticServerUrl { get; set; }

        public static AppSettings GetSettings(IConfiguration config)
        {
            return config.GetSection(nameof(AppSettings)).Get<AppSettings>();
        }
    }
}
