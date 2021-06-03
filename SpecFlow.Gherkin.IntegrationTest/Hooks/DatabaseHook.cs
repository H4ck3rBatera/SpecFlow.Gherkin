using TechTalk.SpecFlow;
using System.Threading;
using Microsoft.Extensions.Configuration;
using SpecFlow.Gherkin.Data.DDL.Definition;
using SpecFlow.Gherkin.Data.DDL.Support.Options.Databases;

namespace SpecFlow.Gherkin.IntegrationTest.Hooks
{
    [Binding]
    public sealed class DatabaseHook
    {
        private static readonly IConfigurationRoot ConfigurationRoot = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
            .AddJsonFile($"appsettings.Development.json", optional: true, reloadOnChange: false)
            .Build();
        
        [BeforeFeature(Order = 0)]
        public static void CleanDatabase()
        {
            var databaseOption = new DatabaseOption();
            ConfigurationRoot.GetSection("ConnectionStrings:Database").Bind(databaseOption);

            var dropDatabase = new DropDatabase(databaseOption);

            var source = new CancellationTokenSource();
            var token = source.Token;

            dropDatabase.DropAsync(token).Wait(token);
        }
    }
}