using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SpecFlow.Gherkin.Data.Scripts;
using SpecFlow.Gherkin.Data.Support.Database;
using SpecFlow.Gherkin.Data.Support.Options.Databases;
using SpecFlow.Gherkin.Domain.Repository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SpecFlow.Gherkin.Data.Repository
{
    public class DatabaseRepository : IDatabaseRepository
    {
        private readonly DatabaseOption _databaseOption;
        private readonly ILogger _logger;

        public DatabaseRepository(IOptions<DatabaseOption> databaseOption, ILogger<DatabaseRepository> logger)
        {
            _databaseOption = databaseOption.Value;
            _logger = logger;
        }

        public async Task CreateAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Entering {nameof(CreateAsync)}");

            try
            {
                using (var connection = Connection.GetSqlConnection(_databaseOption.ConnectionString))
                {
                    using (var command = new SqlCommand(Resource.CreateDatabase, connection))
                    {
                        await command.Connection.OpenAsync(cancellationToken);
                        await command.ExecuteNonQueryAsync(cancellationToken);
                        await command.Connection.CloseAsync();
                    }                    
                }

                _logger.LogInformation($"Created Database!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}