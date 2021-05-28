using System;
using Microsoft.Extensions.DependencyInjection;
using System.Threading;
using SpecFlow.Gherkin.Data.DDL.Definition;

namespace SpecFlow.Gherkin.Data.DDL.Support.Options.Extensions
{
    public static class ServiceProviderExtension
    {
        public static IServiceProvider AddDataProvider(this IServiceProvider serviceProvider)
        {
            var source = new CancellationTokenSource();
            var token = source.Token;

            serviceProvider
                .CreateDatabase(token)
                .CreateTableCustomer(token);

            return serviceProvider;
        }

        public static IServiceProvider CreateDatabase(
            this IServiceProvider serviceProvider,
            CancellationToken cancellationToken)
        {
            var service = serviceProvider.GetService<Database>();
            service.CreateAsync(cancellationToken).Wait();

            return serviceProvider;
        }

        public static IServiceProvider CreateTableCustomer(
            this IServiceProvider serviceProvider,
            CancellationToken cancellationToken)
        {
            var service = serviceProvider.GetService<TableCustomer>();
            service.CreateAsync(cancellationToken).Wait();

            return serviceProvider;
        }
    }
}