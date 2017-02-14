using System.Threading.Tasks;
using Caliburn.Micro.Training.Application.Entity;

namespace Caliburn.Micro.Training.Allication.Services.Services
{
    public interface IUserService
    {
        Task<User> FindUser(int userId);
    }
}
