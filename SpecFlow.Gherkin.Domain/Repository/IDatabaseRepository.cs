using System.Threading;
using System.Threading.Tasks;

namespace SpecFlow.Gherkin.Domain.Repository
{
    public interface IDatabaseRepository
    {
        Task CreateAsync(CancellationToken cancellationToken);
    }
}