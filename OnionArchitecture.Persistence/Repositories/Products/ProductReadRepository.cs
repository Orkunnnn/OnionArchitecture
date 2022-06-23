using OnionArchitecture.Application.Repositories.Products;
using OnionArchitecture.Domain.Entities;
using OnionArchitecture.Persistence.Contexts;
using OnionArchitecture.Persistence.Repositories.Common;

namespace OnionArchitecture.Persistence.Repositories.Products
{
    public class ProductReadRepository : ReadRepository<Product>, IProductReadRepository
    {
        public ProductReadRepository(OnionArchitectureDbContext context) : base(context)
        {
        }
    }
}
