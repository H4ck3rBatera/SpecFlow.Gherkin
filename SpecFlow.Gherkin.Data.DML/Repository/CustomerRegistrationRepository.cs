using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SpecFlow.Gherkin.Domain.Repository;
using System.Threading;
using SpecFlow.Gherkin.Domain.Models;
using SpecFlow.Gherkin.Data.DML.Support.Options.Databases;

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

        public Task<int> RegisterAsync(Customer customer, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Entering {nameof(RegisterAsync)}");

            try
            {
                //using (var connection = new SqlConnection(_customerBaseOption.ConnectionString))
                //{
                //    using (var command = new SqlCommand(Resource., connection))
                //    {
                //        await command.Connection.OpenAsync(cancellationToken);
                //        await command.ExecuteNonQueryAsync(cancellationToken);
                //        await command.Connection.CloseAsync();
                //    }
                //}

                //_logger.LogInformation($"Created Customer!");
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}