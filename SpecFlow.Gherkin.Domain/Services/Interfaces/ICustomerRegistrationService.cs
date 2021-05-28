using SpecFlow.Gherkin.Domain.Models;
using System.Threading;
using System.Threading.Tasks;

namespace SpecFlow.Gherkin.Domain.Services.Interfaces
{
    public interface ICustomerRegistrationService
    {
        Task<int> RegisterAsync(Customer customer, CancellationToken cancellationToken);
    }
}