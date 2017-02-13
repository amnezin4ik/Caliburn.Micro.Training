using System.Data.SqlClient;

namespace Caliburn.Micro.Training.Infrastructure.Database
{
    internal sealed class DatabaseSqlConnectionFactory : IDatabaseSqlConnectionFactory
    {
        private readonly string _connectionString;

        public DatabaseSqlConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public SqlConnection GetSqlConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
