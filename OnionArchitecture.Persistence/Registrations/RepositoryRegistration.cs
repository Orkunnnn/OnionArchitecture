using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnionArchitecture.Application.Registrations;
using OnionArchitecture.Application.Repositories.Categories;
using OnionArchitecture.Application.Repositories.Products;
using OnionArchitecture.Persistence.Repositories.Categories;
using OnionArchitecture.Persistence.Repositories.Products;

namespace OnionArchitecture.Persistence.Registrations
{
    public class RepositoryRegistration : IRegistration
    {
        public void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
            services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
            services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();
        }
    }
}
