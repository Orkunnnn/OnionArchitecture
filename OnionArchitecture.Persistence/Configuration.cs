using Microsoft.Extensions.Configuration;

namespace OnionArchitecture.Persistence
{
    public static class Configuration
    {
        public static string ConnectionString
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../OnionArchitecture.Api")).AddJsonFile("appsettings.json");
                return configurationManager.GetConnectionString("SqlServer");
            }
        }
    }
}
