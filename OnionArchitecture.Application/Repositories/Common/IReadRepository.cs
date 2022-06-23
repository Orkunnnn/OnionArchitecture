using System.Linq.Expressions;
using OnionArchitecture.Domain.Entities.Common;
using OnionArchitecture.Infrastructure.Enums;

namespace OnionArchitecture.Application.Repositories.Common
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll(TrackingState trackingState);
        IQueryable<T> GetAllByFilter(Expression<Func<T, bool>> filter, TrackingState trackingState);
        T? GetByFilter(Expression<Func<T, bool>> filter, TrackingState trackingState);
        T? GetById(Guid id, TrackingState trackingState);
        Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter, TrackingState trackingState);
        Task<T?> GetByIdAsync(Guid id, TrackingState trackingState);
    }
}
