using SpecFlow.Gherkin.Data.Support.Options.Databases;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using SpecFlow.Gherkin.Domain.Repository;
using SpecFlow.Gherkin.Data.Repository;

namespace SpecFlow.Gherkin.Data.Support.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .Configure<DatabaseOption>(configuration.GetSection("ConnectionStrings:Database"))
                .Configure<CustomerBaseOption>(configuration.GetSection("ConnectionStrings:CustomerBase"));

            services
                .AddScoped<IDatabaseRepository, DatabaseRepository>();

            return services;
        }
    }
}