using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SpecFlow.Gherkin.Domain.Repository;
using System.Threading;
using SpecFlow.Gherkin.Domain.Models;
using SpecFlow.Gherkin.Data.DML.Support.Options.Databases;
using Microsoft.Data.SqlClient;
using Dapper;
using SpecFlow.Gherkin.Data.DML.Scripts;

namespace SpecFlow.Gherkin.Data.DML.Repository
{
    public class CustomerRegistrationRepository : ICustomerRegistrationRepository
    {
        private readonly ILogger _logger;
        private readonly CustomerBaseOption _customerBaseOption;

        public CustomerRegistrationRepository(
            ILogger<CustomerRegistrationRepository> logger,
            IOptions<CustomerBaseOption> customerBaseOption)
        {
            _logger = logger;
            _customerBaseOption = customerBaseOption.Value;
        }

        public async Task<int> RegisterAsync(Customer customer, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Entering {nameof(RegisterAsync)}");

            try
            {
                int id;

                await using (var connection = new SqlConnection(_customerBaseOption.ConnectionString))
                {
                    await connection.OpenAsync(cancellationToken);

                    id = await connection.QuerySingleAsync<int>(Resource.InsertCustomer, customer);

                    await connection.CloseAsync();
                }

                _logger.LogInformation($"Created Customer!");

                return id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}