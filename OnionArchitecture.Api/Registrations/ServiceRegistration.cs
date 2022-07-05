using OnionArchitecture.Application.Registrations;

namespace OnionArchitecture.Api.Registrations
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApiRegistrations(this IServiceCollection services, IConfiguration configuration)
        {
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                var registrations = assembly.ExportedTypes.Where(x => typeof(IRegistration).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).Select(Activator.CreateInstance).Cast<IRegistration>().ToList();
                registrations.ForEach(registration => registration.Register(services, configuration));
            }

            return services;
        }
    }
}
