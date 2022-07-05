using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnionArchitecture.Application.Registrations;
using OnionArchitecture.Persistence.Contexts;

namespace OnionArchitecture.Persistence.Registrations
{
    public class DbContextRegistration : IRegistration
    {
        public void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OnionArchitectureDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("SqlServer")));
        }
    }
}
