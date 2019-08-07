using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Pandora.NetCore.ApiHost
{
    /// <summary>
    /// 
    /// </summary>
    public class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        //private static void RunSeeding(IWebHost host)
        //{
        //    var scopeFactory = host.Services.GetService<IServiceScopeFactory>();
        //    using (var scope = scopeFactory.CreateScope())
        //    {
        //        var seeder = scope.ServiceProvider.GetService<AnyService>();
        //        seeder.SeedAsync().Wait();
        //    }
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
             WebHost.CreateDefaultBuilder(args)
                 .ConfigureServices(services =>
                 {
                     //services.AddTransient<IStartupFilter, HostStartupFilter>();
                }).UseStartup<Startup>();

    }
}
