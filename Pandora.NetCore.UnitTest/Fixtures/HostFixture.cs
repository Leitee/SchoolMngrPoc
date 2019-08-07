using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Pandora.NetStandard.Business.Services;
using Pandora.NetStandard.Business.Services.Contracts;
using Pandora.NetStandard.Core.Interfaces;
using Pandora.NetStandard.Core.Mapper;
using Pandora.NetStandard.Data.Dals;

namespace Pandora.NetCore.UnitTest
{
    public class HostFixture
    {
        public TestServer Server { get; }

        public HostFixture()
        {
            var builder = new WebHostBuilder()
            .ConfigureServices(services =>
            {
                services.AddSingleton<RepositoryFactories<TestDbContext>>();
                services.AddSingleton<IMapperCore, GenericMapperCore>();
                services.AddScoped<ILogger, Logger<TestServer>>();
                services.AddScoped<IRepositoryProvider<TestDbContext>, RepositoryProvider<TestDbContext>>();
                services.AddScoped<IApplicationUow, ApplicationUow<TestDbContext>>();
                services.AddScoped<IGradeSvc, GradeSvc>();
                services.AddScoped<IClassSvc, ClassSvc>();
                services.AddScoped<IStudentSvc, StudentSvc>();
                services.AddScoped<ISubjectSvc, SubjectSvc>();
                services.AddScoped<IStudentStateSvc, StudentStateSvc>();
            })
            .UseStartup<TestStartup>();

            Server = new TestServer(builder);
        }
    }
}
