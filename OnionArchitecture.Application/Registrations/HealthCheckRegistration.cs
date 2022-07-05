using Azure.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace OnionArchitecture.Application.Registrations
{
    public class HealthCheckRegistration : IRegistration
    {
        public void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks().AddSqlServer(configuration.GetConnectionString("SqlServer")).AddAzureKeyVault(new(configuration["KeyVault:VaultUri"]), new DefaultAzureCredential(), options => { });
        }
    }
}
