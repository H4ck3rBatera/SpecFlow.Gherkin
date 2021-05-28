using Microsoft.Extensions.Logging;
using SpecFlow.Gherkin.Domain.Models;
using SpecFlow.Gherkin.Domain.Repository;
using SpecFlow.Gherkin.Domain.Services.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace SpecFlow.Gherkin.Domain.Services
{
    public class CustomerRegistrationService : ICustomerRegistrationService
    {
        private readonly ILogger _logger;
        private readonly ICustomerRegistrationRepository _customerRegistrationRepository;

        public CustomerRegistrationService(
            ILogger<CustomerRegistrationService> logger,
            ICustomerRegistrationRepository customerRegistrationRepository)
        {
            _logger = logger;
            _customerRegistrationRepository = customerRegistrationRepository;
        }

        public async Task<int> RegisterAsync(Customer customer, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Entering {nameof(RegisterAsync)}");

            return await _customerRegistrationRepository.RegisterAsync(customer, cancellationToken);
        }
    }
}