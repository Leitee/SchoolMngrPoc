using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Pandora.NetStandard.Application;

namespace Pandora.NetCore.UnitTest
{
    internal class TestStartup
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
