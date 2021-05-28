using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using SpecFlow.Gherkin.Domain.Services;
using SpecFlow.Gherkin.Domain.Services.Interfaces;

namespace SpecFlow.Gherkin.Domain.Support.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDomain(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddScoped<ICustomerRegistrationService, CustomerRegistrationService>();

            return services;
        }
    }
}