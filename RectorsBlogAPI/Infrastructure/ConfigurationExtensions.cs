using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RectorsBlogAPI.Infrastructure
{
    public static class ConfigurationExtensions
    {
        public static string GetDefaultConnectionString(this IConfiguration configuration) 
            => configuration.GetConnectionString("SQLServerConnection");

    }
}
