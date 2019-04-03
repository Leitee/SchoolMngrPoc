using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pandora.NetStandard.Data.Dals;

namespace Pandora.NetCore.UnitTest
{
    public class DbContextMocker
    {
        public DbContextMocker(IServiceCollection services)
        {
            services.AddDbContext<SchoolDbContext>(builder =>
            {
                builder.UseInMemoryDatabase("Test");
            });
        }

        public static SchoolDbContext GetApplicationDbContext(string dbName)
        {
            // Create options for DbContext instance
            var options = new DbContextOptionsBuilder<SchoolDbContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            // Create instance of DbContext
            var dbContext = new SchoolDbContext(null, options);

            // Add entities in memory
            dbContext.SeedDb();

            return dbContext;
        }
    }
}
