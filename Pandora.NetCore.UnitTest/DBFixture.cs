using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pandora.NetCore.UnitTest
{
    public class DBFixture : IDisposable
    {
        public DBFixture(IServiceCollection services)
        {
            services.AddDbContext<UnitTestDbContext>();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
