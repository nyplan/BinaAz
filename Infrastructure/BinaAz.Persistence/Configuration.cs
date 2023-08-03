using Microsoft.Extensions.Configuration;

namespace BinaAz.Persistence;

public static class Configuration
{
    public static string ConnectionString
    {
        get
        {
            ConfigurationManager configurationManager = new();
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/BinaAz.API"));
            configurationManager.AddJsonFile("appsettings.json");
            return configurationManager.GetConnectionString("PostgreSQL")!;
        }
    }
}