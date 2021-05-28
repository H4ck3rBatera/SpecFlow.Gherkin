using SpecFlow.Gherkin.Domain.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SpecFlow.Gherkin.Data.DML.Repository;
using SpecFlow.Gherkin.Data.DML.Support.Options.Databases;

namespace SpecFlow.Gherkin.Data.DML.Support.Options.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDmlData(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .Configure<CustomerBaseOption>(configuration.GetSection("ConnectionStrings:CustomerBase"));

            services
                .AddScoped<ICustomerRegistrationRepository, CustomerRegistrationRepository>();

            return services;
        }
    }
}