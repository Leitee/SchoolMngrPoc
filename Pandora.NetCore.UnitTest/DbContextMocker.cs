using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pandora.NetStandard.Data.Dals;
using System;

namespace Pandora.NetCore.UnitTest
{
    public class DbContextMocker : IDisposable
    {
        //public DbContextMocker(IServiceCollection services)
        //{
        //    services.AddDbContext<UnitTestDbContext>(builder =>
        //    {
        //        builder.UseInMemoryDatabase("Test");
        //    });
        //}

        public ApplicationUow<UnitTestDbContext> GetApplicationUoW(string dbName)
        {
            // Create options for DbContext instance
            var options = new DbContextOptionsBuilder<UnitTestDbContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            // Create instance of DbContext
            var dbContext = new UnitTestDbContext(null, options);

            return new ApplicationUow<UnitTestDbContext>(new RepositoryProvider<UnitTestDbContext>(dbContext, null, null));

            // Add entities in memory
            //dbContext.SeedDb();

            //return dbContext;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
