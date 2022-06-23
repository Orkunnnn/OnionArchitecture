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
                configurationManager.SetBasePath(Directory.GetCurrentDirectory());
                configurationManager.AddJsonFile("appsettings.json").AddUserSecrets("7bc21b82-df20-428b-9607-cbe0a12ad0e1");
                return configurationManager.GetConnectionString("SqlServer");
            }
        }
    }
}
