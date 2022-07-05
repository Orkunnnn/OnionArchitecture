using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace OnionArchitecture.Application.Registrations
{
    public interface IRegistration
    {
        void Register(IServiceCollection services, IConfiguration configuration);
    }
}
