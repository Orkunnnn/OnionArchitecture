using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace OnionArchitecture.Application.Registrations
{
    public class AutoMapperRegistration : IRegistration
    {
        public void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(AutoMapperRegistration));
        }
    }
}
