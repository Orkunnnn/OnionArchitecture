using OnionArchitecture.Domain.Entities.Common;

namespace OnionArchitecture.Application.Repositories.Common
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<T> AddAsync(Task entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        bool Remove(T entity);
        Task<bool> RemoveAsync(Guid id);
        bool Update(T entity);
        Task<int> SaveAsync();
    }
}
