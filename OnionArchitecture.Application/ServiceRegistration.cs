using System.Reflection;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace OnionArchitecture.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            var serviceRegistrationType = typeof(ServiceRegistration);
            services.AddMediatR(serviceRegistrationType);
            services.AddAutoMapper(serviceRegistrationType);
            services.AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));
        }
    }
}
