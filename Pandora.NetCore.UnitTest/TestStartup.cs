using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Pandora.NetStandard.Api;

namespace Pandora.NetCore.UnitTest
{
    public class TestStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TestDbContext>();
            Configuration.ConfigureApiServices(services);
        }

        public void Configure(IApplicationBuilder app)
        {
            Configuration.ConfigureApi(app, host =>
            {
                return host;
            });
        }
    }
}
