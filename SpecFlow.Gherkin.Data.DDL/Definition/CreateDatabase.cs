using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SpecFlow.Gherkin.Data.DDL.Scripts;
using SpecFlow.Gherkin.Data.DDL.Support.Options.Databases;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SpecFlow.Gherkin.Data.DDL.Definition
{
    public class CreateDatabase
    {
        private readonly ILogger _logger;
        private readonly DatabaseOption _databaseOption;

        public CreateDatabase(
            ILogger<CreateDatabase> logger,
            IOptions<DatabaseOption> databaseOption)
        {
            _logger = logger;
            _databaseOption = databaseOption.Value;
        }

        public async Task CreateAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Entering {nameof(CreateTableCustomer)} {nameof(CreateAsync)}");

            try
            {
                await using (var connection = new SqlConnection(_databaseOption.ConnectionString))
                {
                    await using (var command = new SqlCommand(Resource.CreateDatabase, connection))
                    {
                        await command.Connection.OpenAsync(cancellationToken);
                        await command.ExecuteNonQueryAsync(cancellationToken);
                        await command.Connection.CloseAsync();
                    }
                }

                _logger.LogInformation($"Created {nameof(Resource.CreateDatabase)}!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}