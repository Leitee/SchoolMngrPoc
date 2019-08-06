using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Pandora.NetCore.UnitTest
{
    public class TestStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //Configuration.ConfigureServices(services);
        }

        public void Configure(IApplicationBuilder app)
        {
            //Configuration.Configure(app, host =>
            //{
            //    return host;
            //});
        }
    }
}
