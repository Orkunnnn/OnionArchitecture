using OnionArchitecture.Domain.Entities.Common;

namespace OnionArchitecture.Application.Repositories.Common
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        T Add(T entity);
        T Update(T entity);
        bool Remove(Guid id);
        int Save();
        Task<int> SaveAsync();
    }
}
