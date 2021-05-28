using SpecFlow.Gherkin.Domain.Models;
using System.Threading;
using System.Threading.Tasks;

namespace SpecFlow.Gherkin.Domain.Repository
{
    public interface ICustomerRegistrationRepository
    {
        Task<int> RegisterAsync(Customer customer, CancellationToken cancellationToken);
    }
}