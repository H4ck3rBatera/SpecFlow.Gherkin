using Microsoft.Data.SqlClient;

namespace SpecFlow.Gherkin.Data.Support.Database
{
    public static class Connection
    {
        public static SqlConnection GetSqlConnection(string connectionString)
        {
            return new SqlConnection(connectionString);
        }
    }
}