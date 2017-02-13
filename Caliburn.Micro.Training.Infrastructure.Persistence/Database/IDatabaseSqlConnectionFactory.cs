using System.Data.SqlClient;

namespace Caliburn.Micro.Training.Infrastructure.Database
{
    public interface IDatabaseSqlConnectionFactory
    {
        SqlConnection GetSqlConnection();
    }
}
