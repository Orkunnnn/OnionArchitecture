using System.Reflection;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace OnionArchitecture.Application.Registrations
{
    public class FluentValidationRegistration : IRegistration
    {
        public void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));
        }
    }
}
