using Microsoft.EntityFrameworkCore;
using Pandora.NetStandard.Data.Dals;

namespace Pandora.NetCore.UnitTest
{
    public static class DbContextMocker
    {
        public static SchoolDbContext GetApplicationDbContext(string dbName)
        {
            // Create options for DbContext instance
            var options = new DbContextOptionsBuilder<SchoolDbContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            // Create instance of DbContext
            var dbContext = new SchoolDbContext(null, options);

            // Add entities in memory
            dbContext.Seed();

            return dbContext;
        }
    }
}
