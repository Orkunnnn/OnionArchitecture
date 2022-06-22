using System.Linq.Expressions;
using OnionArchitecture.Application.Enums;
using OnionArchitecture.Domain.Entities.Common;

namespace OnionArchitecture.Application.Repositories.Common
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll(TrackingState trackingState);
        IQueryable<T> GetAllByFilter(Expression<Func<T, bool>> filter, TrackingState trackingState);
        Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter, TrackingState trackingState);
        Task<T> GetByIdAsync(Guid id);
    }
}
