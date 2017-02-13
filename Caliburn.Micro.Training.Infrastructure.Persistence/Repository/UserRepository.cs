using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Caliburn.Micro.Training.Infrastructure.Database;
using Caliburn.Micro.Training.Infrastructure.Dto;
using Dapper;

namespace Caliburn.Micro.Training.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IDatabaseSqlConnectionFactory _databaseSqlConnectionFactory;

        public UserRepository(IDatabaseSqlConnectionFactory databaseSqlConnectionFactory)
        {
            _databaseSqlConnectionFactory = databaseSqlConnectionFactory;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            using (IDbConnection db = _databaseSqlConnectionFactory.GetSqlConnection())
            {
                var users = await db.QueryAsync<User>("SELECT * FROM [User]");
                return users.ToList();
            }
        }

        public async Task<User> GetAsync(int userId)
        {
            using (IDbConnection db = _databaseSqlConnectionFactory.GetSqlConnection())
            {
                var userQuery = await db.QueryAsync<User>("SELECT * FROM [User] WHERE Id = @id", new { userId });
                return userQuery.FirstOrDefault();
            }
        }

        public async Task<User> CreateAsync(User user)
        {
            using (IDbConnection db = _databaseSqlConnectionFactory.GetSqlConnection())
            {
                var sqlQuery = "INSERT INTO [User] (Name, Age) VALUES(@Name, @Age); SELECT CAST(SCOPE_IDENTITY() as int)";
                var userIdQuery = await db.QueryAsync<int>(sqlQuery, user);
                var userId = userIdQuery.FirstOrDefault();
                user.Id = userId;
            }
            return user;
        }

        public async Task UpdateAsync(User user)
        {
            using (IDbConnection db = _databaseSqlConnectionFactory.GetSqlConnection())
            {
                var sqlQuery = "UPDATE [User] SET Name = @Name, Age = @Age WHERE Id = @Id";
                await db.ExecuteAsync(sqlQuery, user);
            }
        }

        public async Task DeleteAsync(int userId)
        {
            using (IDbConnection db = _databaseSqlConnectionFactory.GetSqlConnection())
            {
                var sqlQuery = "DELETE FROM [User] WHERE Id = @id";
                await db.ExecuteAsync(sqlQuery, new { userId });
            }
        }
    }
}
