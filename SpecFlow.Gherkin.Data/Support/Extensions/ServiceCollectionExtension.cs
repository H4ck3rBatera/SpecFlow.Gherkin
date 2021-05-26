using SpecFlow.Gherkin.Data.Support.Options.Databases;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace SpecFlow.Gherkin.Data.Support.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .Configure<CustomerBaseOption>(configuration.GetSection("ConnectionStrings:CustomerBase"));

            return services;
        }
    }
}