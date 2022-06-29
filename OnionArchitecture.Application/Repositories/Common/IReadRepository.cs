using System.Linq.Expressions;
using OnionArchitecture.Application.Enums;
using OnionArchitecture.Domain.Entities.Common;

namespace OnionArchitecture.Application.Repositories.Common
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll(TrackingState trackingState = TrackingState.WithTracking);
        IQueryable<T> GetAllByFilter(Expression<Func<T, bool>> filter, TrackingState trackingState = TrackingState.WithTracking);
        T? GetByFilter(Expression<Func<T, bool>> filter, TrackingState trackingState);
        T? GetById(Guid id, TrackingState trackingState = TrackingState.WithTracking);
        Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter, TrackingState trackingState = TrackingState.WithTracking);
        Task<T?> GetByIdAsync(Guid id, TrackingState trackingState = TrackingState.WithTracking);
    }
}
