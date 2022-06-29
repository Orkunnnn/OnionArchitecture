using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using OnionArchitecture.Persistence.Contexts;

namespace OnionArchitecture.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<OnionArchitectureDbContext>
    {
        private IConfiguration _configuration;

        public DesignTimeDbContextFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public OnionArchitectureDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<OnionArchitectureDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseSqlServer(_configuration.GetConnectionString("SqlServer"));
            return new(dbContextOptionsBuilder.Options, _configuration);
        }
    }
}
