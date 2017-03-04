using System.Collections.Generic;
using System.Threading.Tasks;
using Caliburn.Micro.Training.Infrastructure.Dto;

namespace Caliburn.Micro.Training.Infrastructure.Repository
{
    public interface IUserRepository
    {
        Task<User> CreateAsync(User user);
        Task DeleteAsync(int userId);
        Task<User> GetAsync(int userId);
        Task<IEnumerable<User>> GetAllAsync();
        Task UpdateAsync(User user);
        Task<bool> IsEmailUniqueAsync(string email);
    }
}
