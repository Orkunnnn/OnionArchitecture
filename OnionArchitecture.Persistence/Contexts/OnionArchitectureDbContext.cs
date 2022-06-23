using System.Reflection;
using Microsoft.EntityFrameworkCore;
using OnionArchitecture.Domain.Entities;

namespace OnionArchitecture.Persistence.Contexts
{
    public class OnionArchitectureDbContext : DbContext
    {
        public OnionArchitectureDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }



        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public DbSet<Product> Products { get; set; } = default!;
        public DbSet<Category> Categories { get; set; } = default!;
    }
}
