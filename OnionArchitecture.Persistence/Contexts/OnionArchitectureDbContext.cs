using System.Reflection;
using Microsoft.EntityFrameworkCore;
using OnionArchitecture.Domain.Entities;
using OnionArchitecture.Domain.Entities.Common;

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
            foreach (var item in ChangeTracker.Entries<BaseEntity>())
            {
                _ = item.State switch
                {
                    EntityState.Added => item.Entity.CreatedDate = DateTime.Now,
                    EntityState.Modified => item.Entity.UpdatedDate = DateTime.Now,
                    _ => default
                };
            }
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var item in ChangeTracker.Entries<BaseEntity>())
            {
                _ = item.State switch
                {
                    EntityState.Added => item.Entity.CreatedDate = DateTime.Now,
                    EntityState.Modified => item.Entity.UpdatedDate = DateTime.Now,
                    _ => default
                };
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<Product> Products { get; set; } = default!;
        public DbSet<Category> Categories { get; set; } = default!;
    }
}
