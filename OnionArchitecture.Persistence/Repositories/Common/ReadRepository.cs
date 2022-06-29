using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using OnionArchitecture.Application.Enums;
using OnionArchitecture.Application.Repositories.Common;
using OnionArchitecture.Domain.Entities.Common;
using OnionArchitecture.Persistence.Contexts;

namespace OnionArchitecture.Persistence.Repositories.Common
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly OnionArchitectureDbContext _context;

        public ReadRepository(OnionArchitectureDbContext context)
        {
            this._context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(TrackingState trackingState = TrackingState.WithTracking) => trackingState == TrackingState.NoTracking ? Table.AsNoTracking() : Table.AsQueryable();

        public IQueryable<T> GetAllByFilter(Expression<Func<T, bool>> filter, TrackingState trackingState = TrackingState.WithTracking) => trackingState == TrackingState.NoTracking ? Table.Where(filter).AsNoTracking() : Table.Where(filter);

        public T? GetByFilter(Expression<Func<T, bool>> filter, TrackingState trackingState = TrackingState.WithTracking) => trackingState == TrackingState.NoTracking ? Table.AsNoTracking().FirstOrDefault(filter) : Table.FirstOrDefault(filter);

        public Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter, TrackingState trackingState = TrackingState.WithTracking) => trackingState == TrackingState.NoTracking ? Table.AsNoTracking().FirstOrDefaultAsync(filter) : Table.FirstOrDefaultAsync(filter);

        public T? GetById(Guid id, TrackingState trackingState = TrackingState.WithTracking) => trackingState == TrackingState.NoTracking ? Table.AsNoTracking().FirstOrDefault(entity => entity.Id == id) : Table.FirstOrDefault(entity => entity.Id == id);

        public Task<T?> GetByIdAsync(Guid id, TrackingState trackingState = TrackingState.WithTracking) => trackingState == TrackingState.NoTracking ? Table.AsNoTracking().FirstOrDefaultAsync(entity => entity.Id == id) : Table.FirstOrDefaultAsync(entity => entity.Id == id);
    }
}
