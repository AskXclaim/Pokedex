using Microsoft.Extensions.Configuration;

namespace Pokedex.Service.Common
{
    /// <summary>
    /// A static class to allow access to configuration settings in the appsettings.json file.
    /// </summary>
    public static class ConfigurationHolder
    {
        public static IConfiguration Configuration;
    }
}