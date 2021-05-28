using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace SpecFlow.Gherkin.IntegrationTest.Support.Extensions
{
    public static class ConfigurationExtensions
    {
        public static IConfigurationBuilder AddTestConfig(this IConfigurationBuilder configurationBuilder, IWebHostEnvironment webHostEnvironment)
        {
            configurationBuilder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
                                .AddJsonFile($"appsettings.{webHostEnvironment.EnvironmentName}.json", optional: true, reloadOnChange: false);

            return configurationBuilder;
        }
    }
}