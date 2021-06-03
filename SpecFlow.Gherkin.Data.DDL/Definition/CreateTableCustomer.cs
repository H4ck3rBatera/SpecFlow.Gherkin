using System;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SpecFlow.Gherkin.Data.DDL.Scripts;
using SpecFlow.Gherkin.Data.DDL.Support.Options.Databases;
using System.Threading;

namespace SpecFlow.Gherkin.Data.DDL.Definition
{
    public class CreateTableCustomer
    {
        private readonly ILogger _logger;
        private readonly CustomerBaseOption _customerBaseOption;

        public CreateTableCustomer(
            ILogger<CreateDatabase> logger,
            IOptions<CustomerBaseOption> customerBaseOption)
        {
            _logger = logger;
            _customerBaseOption = customerBaseOption.Value;
        }

        public async Task CreateAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Entering {nameof(CreateTableCustomer)} {nameof(CreateAsync)}");

            try
            {
                await using (var connection = new SqlConnection(_customerBaseOption.ConnectionString))
                {
                    await using (var command = new SqlCommand(Resource.CreateTableCustomer, connection))
                    {
                        await command.Connection.OpenAsync(cancellationToken);
                        await command.ExecuteNonQueryAsync(cancellationToken);
                        await command.Connection.CloseAsync();
                    }
                }

                _logger.LogInformation($"Created {nameof(Resource.CreateTableCustomer)}!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
