using OnionArchitecture.Application.Repositories.Products;
using OnionArchitecture.Domain.Entities;
using OnionArchitecture.Persistence.Contexts;
using OnionArchitecture.Persistence.Repositories.Common;

namespace OnionArchitecture.Persistence.Repositories.Products
{
    public class ProductWriteRepository : WriteRepository<Product>, IProductWriteRepository
    {
        public ProductWriteRepository(OnionArchitectureDbContext context) : base(context)
        {
        }
    }
}
