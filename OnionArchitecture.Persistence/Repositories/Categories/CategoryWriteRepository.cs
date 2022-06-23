using OnionArchitecture.Application.Repositories.Categories;
using OnionArchitecture.Domain.Entities;
using OnionArchitecture.Persistence.Contexts;
using OnionArchitecture.Persistence.Repositories.Common;

namespace OnionArchitecture.Persistence.Repositories.Categories
{
    public class CategoryWriteRepository : WriteRepository<Category>, ICategoryWriteRepository
    {
        public CategoryWriteRepository(OnionArchitectureDbContext context) : base(context)
        {
        }
    }
}
