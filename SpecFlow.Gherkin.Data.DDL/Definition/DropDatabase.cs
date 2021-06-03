using Microsoft.Data.SqlClient;
using SpecFlow.Gherkin.Data.DDL.Scripts;
using SpecFlow.Gherkin.Data.DDL.Support.Options.Databases;
using System.Threading;
using System.Threading.Tasks;

namespace SpecFlow.Gherkin.Data.DDL.Definition
{
    public class DropDatabase
    {
        private readonly DatabaseOption _databaseOption;

        public DropDatabase(DatabaseOption databaseOption)
        {
            _databaseOption = databaseOption;
        }

        public async Task DropAsync(CancellationToken cancellationToken)
        {
            await using var connection = new SqlConnection(_databaseOption.ConnectionString);
            await using var command = new SqlCommand(Resource.DropDatabase, connection);
            await command.Connection.OpenAsync(cancellationToken);
            await command.ExecuteNonQueryAsync(cancellationToken);
            await command.Connection.CloseAsync();
        }
    }
}