using Microsoft.EntityFrameworkCore;
using Pandora.NetStandard.Data.Dals;
using System;

namespace Pandora.NetCore.UnitTest
{
    public class TestDbContextMocker : IDisposable
    {
        public ApplicationUow<TestDbContext> UoW { get; private set; }

        public TestDbContextMocker()
        {
            UoW = GetApplicationUoW(nameof(TestDbContext));
        }

        public ApplicationUow<TestDbContext> GetApplicationUoW(string dbName)
        {
            // Create options for DbContext instance
            var options = new DbContextOptionsBuilder<TestDbContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            // Create instance of DbContext
            var dbContext = new TestDbContext(options);

            // Force create entities in memory
            dbContext.Database.EnsureCreated();

            return new ApplicationUow<TestDbContext>(dbContext, new RepositoryProvider<TestDbContext>(dbContext, null, null));
        }

        public void Dispose()
        {
            UoW.Dispose();
        }
    }
}
