using Microsoft.EntityFrameworkCore;
using OnionArchitecture.Domain.Entities.Common;

namespace OnionArchitecture.Application.Repositories.Common
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
    }
}
