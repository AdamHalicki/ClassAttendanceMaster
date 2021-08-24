using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Persistance.DbContextOptionsProviders
{
    public abstract class DbContextOptionsProvider<TDbContext>
        where TDbContext : DbContext
    {
        protected readonly IConfiguration configuration;
        protected readonly ILoggerFactory loggerFactory;

        public DbContextOptionsProvider(IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            this.configuration = configuration;
            this.loggerFactory = loggerFactory;
        }

        public abstract DbContextOptions<TDbContext> CreateInstance();
    }
}
