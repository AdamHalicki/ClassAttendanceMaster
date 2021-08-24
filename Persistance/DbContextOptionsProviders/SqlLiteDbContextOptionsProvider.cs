using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Persistance.DbContextOptionsProviders
{
    public class SqlLiteDbContextOptionsProvider<TDbContext> : DbContextOptionsProvider<TDbContext>
        where TDbContext : DbContext
    {
        public SqlLiteDbContextOptionsProvider(IConfiguration configuration, ILoggerFactory loggerFactory) : base(configuration, loggerFactory)
        {
        }

        public override DbContextOptions<TDbContext> CreateInstance()
        {
            var connectionString = configuration.GetConnectionString("SqlLiteConnection");
            var optionsBuilder = new DbContextOptionsBuilder<TDbContext>();

            optionsBuilder.UseLoggerFactory(loggerFactory);
            optionsBuilder.UseSqlite(connectionString);

            return optionsBuilder.Options;
        }
    }
}
