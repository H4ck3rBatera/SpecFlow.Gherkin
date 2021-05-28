using SpecFlow.Gherkin.Domain.Models;
using SpecFlow.Gherkin.Domain.Services.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace SpecFlow.Gherkin.Domain.Services
{
    public class CustomerRegistrationService : ICustomerRegistrationService
    {
        public Task<int> RegisterAsync(Customer customer, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}