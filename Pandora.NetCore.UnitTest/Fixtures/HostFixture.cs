using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Pandora.NetStandard.Business.Services;
using Pandora.NetStandard.Business.Services.Contracts;
using Pandora.NetStdLibrary.Base.Identity;
using Pandora.NetStdLibrary.Base.Interfaces;
using Pandora.NetStdLibrary.Base.Interfaces.Identity;
using Pandora.NetStdLibrary.Base.Mapper;
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
                //setting identity options 
                services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddUserManager<UserManagerFacade>()
                .AddRoleManager<RoleManagerFacade>()
                .AddSignInManager<AccountManagerFacade>()
                .AddEntityFrameworkStores<TestDbContext>();

                services.AddScoped<ILogger, Logger<TestServer>>();
                services.AddSingleton<RepositoryFactories<TestDbContext>>();
                services.AddSingleton<IMapperCore, GenericMapper>();
                services.AddScoped<IRepositoryProvider<TestDbContext>, RepositoryProvider<TestDbContext>>();
                services.AddScoped<IIdentityAppUow, ApplicationUow<TestDbContext>>();
                services.AddScoped<IRoleRepository, RoleManagerFacade>();
                services.AddScoped<IUserRepository, UserManagerFacade>();
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
