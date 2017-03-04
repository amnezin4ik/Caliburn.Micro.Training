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
                var userQuery = await db.QueryAsync<User>("SELECT * FROM [User] WHERE Id = @userId", new { userId });
                return userQuery.FirstOrDefault();
            }
        }

        public async Task<User> CreateAsync(User user)
        {
            using (IDbConnection db = _databaseSqlConnectionFactory.GetSqlConnection())
            {
                var sqlQuery = @"
                    INSERT INTO [User] (FirstName, LastName, Email, DateOfBirth, PhotoPath) 
                    VALUES(@FirstName, @LastName, @Email, @DateOfBirth, @PhotoPath); 
                    SELECT CAST(SCOPE_IDENTITY() as int)";
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
                var sqlQuery = @"
                    UPDATE [User] SET FirstName = @FirstName, LastName = @LastName, Email = @Email, DateOfBirth = @DateOfBirth, PhotoPath = @PhotoPath
                    WHERE Id = @Id";
                await db.ExecuteAsync(sqlQuery, user);
            }
        }

        public async Task DeleteAsync(int userId)
        {
            using (IDbConnection db = _databaseSqlConnectionFactory.GetSqlConnection())
            {
                var sqlQuery = "DELETE FROM [User] WHERE Id = @userId";
                await db.ExecuteAsync(sqlQuery, new { userId });
            }
        }

        public async Task<bool> IsEmailUniqueAsync(string email)
        {
            using (IDbConnection db = _databaseSqlConnectionFactory.GetSqlConnection())
            {
                var sqlQuery = "SELECT TOP 1 Email FROM [User] WHERE Email = @email";
                var existingEmail = await db.QueryAsync<string>(sqlQuery, email);
                var emailExists = existingEmail.Any();
                return emailExists;
            }
        }
    }
}
