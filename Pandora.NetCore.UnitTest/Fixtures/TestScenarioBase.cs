using Microsoft.AspNetCore.TestHost;
using Pandora.NetStandard.Core.Base;
using Xunit;

namespace Pandora.NetCore.UnitTest.Fixtures
{
    public abstract class TestScenarioBase<TController> : IClassFixture<HostFixture> where TController : ApiBaseController
    {
        private readonly HostFixture _testHost;
        protected readonly TestDbContext _context;
        protected TController Controller { get; private set; }

        public TestScenarioBase(HostFixture hostFixture)
        {
            _testHost = hostFixture;
            _context = hostFixture.Server.Host.Services.GetService(typeof(TestDbContext)) as TestDbContext;
            _context.Database.EnsureCreated();
            Controller = GetControllerInstance();
        }

        protected abstract TController GetControllerInstance();

        protected TestServer GetServer()
        {
            return _testHost.Server;
        }

        protected TInstance GetContainerInstance<TInstance>() where TInstance : class
        {
            return _testHost.Server.Host.Services.GetService(typeof(TInstance)) as TInstance;
        }
    }
}
