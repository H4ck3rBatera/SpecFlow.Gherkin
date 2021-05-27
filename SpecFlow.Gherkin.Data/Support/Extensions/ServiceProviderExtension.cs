using System;
using Microsoft.Extensions.DependencyInjection;
using System.Threading;
using SpecFlow.Gherkin.Domain.Repository;

namespace SpecFlow.Gherkin.Data.Support.Extensions
{
    public static class ServiceProviderExtension
    {
        public static IServiceProvider AddDataProvider(this IServiceProvider serviceProvider)
        {
            var source = new CancellationTokenSource();
            var token = source.Token;

            var database = serviceProvider.GetService<IDatabaseRepository>();
            database.CreateAsync(token).Wait();

            return serviceProvider;
        }
    }
}