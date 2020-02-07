using Microsoft.Extensions.Configuration;
using System.IO;

namespace PizzaTime.VoiceFileGenerator
{
    public static class LambdaConfiguration
    {
        private static IConfigurationRoot _configuration = null;
        public static IConfigurationRoot Configuration => _configuration ??
                       (_configuration = new ConfigurationBuilder()
                                         .SetBasePath(Directory.GetCurrentDirectory())
                                         .AddJsonFile("appsettings.json")
                                         .AddEnvironmentVariables()
                                         .Build());
    }
}
