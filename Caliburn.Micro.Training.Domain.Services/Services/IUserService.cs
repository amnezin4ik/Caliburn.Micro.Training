using System.Collections.Generic;
using System.Threading.Tasks;
using Caliburn.Micro.Training.Domain.Model;

namespace Caliburn.Micro.Training.Domain.Services.Services
{
    public interface IUserService
    {
        Task<User> FindUserAsync(int userId);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task DeleteUserAsync(int userId);
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task<bool> IsUserEmailUniqueAsync(string email);
    }
}
