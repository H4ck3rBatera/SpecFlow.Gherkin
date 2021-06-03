using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SpecFlow.Gherkin.Data.DDL.Definition;
using SpecFlow.Gherkin.Data.DDL.Support.Options.Databases;

namespace SpecFlow.Gherkin.Data.DDL.Support.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDdlData(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .Configure<DatabaseOption>(configuration.GetSection("ConnectionStrings:Database"))
                .Configure<CustomerBaseOption>(configuration.GetSection("ConnectionStrings:CustomerBase"));

            services
                .AddScoped<CreateDatabase>()
                .AddScoped<CreateTableCustomer>();

            return services;
        }
    }
}