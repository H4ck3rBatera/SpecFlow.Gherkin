using System;
using System.Threading;
using Microsoft.Extensions.DependencyInjection;
using SpecFlow.Gherkin.Data.DDL.Definition;

namespace SpecFlow.Gherkin.Data.DDL.Support.Extensions
{
    public static class ServiceProviderExtension
    {
        public static IServiceProvider AddDataProvider(this IServiceProvider serviceProvider)
        {
            var source = new CancellationTokenSource();
            var token = source.Token;

            return serviceProvider
                    .CreateDatabase(token)
                    .CreateTableCustomer(token);
        }

        private static IServiceProvider CreateDatabase(
            this IServiceProvider serviceProvider,
            CancellationToken cancellationToken)
        {
            var service = serviceProvider.GetService<CreateDatabase>();
            service?.CreateAsync(cancellationToken).Wait(cancellationToken);

            return serviceProvider;
        }

        private static IServiceProvider CreateTableCustomer(
            this IServiceProvider serviceProvider,
            CancellationToken cancellationToken)
        {
            var service = serviceProvider.GetService<CreateTableCustomer>();
            service?.CreateAsync(cancellationToken).Wait(cancellationToken);

            return serviceProvider;
        }
    }
}