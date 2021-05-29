using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SpecFlow.Gherkin.Data.DML.Repository;
using SpecFlow.Gherkin.Data.DML.Support.Options.Databases;
using SpecFlow.Gherkin.Domain.Repository;

namespace SpecFlow.Gherkin.Data.DML.Support.Extensions
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