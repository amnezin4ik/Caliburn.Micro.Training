using System.Threading.Tasks;
using Caliburn.Micro.Training.Domain.Model;

namespace Caliburn.Micro.Training.Domain.Services.Services
{
    public interface IUserService
    {
        Task<User> FindUser(int userId);
    }
}
