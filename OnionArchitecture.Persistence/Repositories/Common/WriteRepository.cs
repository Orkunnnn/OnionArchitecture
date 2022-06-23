using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using OnionArchitecture.Application.Repositories.Common;
using OnionArchitecture.Domain.Entities.Common;
using OnionArchitecture.Persistence.Contexts;

namespace OnionArchitecture.Persistence.Repositories.Common
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly OnionArchitectureDbContext _context;

        public WriteRepository(OnionArchitectureDbContext context)
        {
            this._context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public Task<EntityEntry<T>> AddAsync(T entity) => Table.AddAsync(entity);

        public Task AddRangeAsync(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveAsync()
        {
            throw new NotImplementedException();
        }

        public bool Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
