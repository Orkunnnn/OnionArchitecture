using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using OnionArchitecture.Persistence.Contexts;

namespace OnionArchitecture.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<OnionArchitectureDbContext>
    {
        public OnionArchitectureDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<OnionArchitectureDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseSqlServer(Configuration.ConnectionString);
            return new(dbContextOptionsBuilder.Options);
        }
    }
}
