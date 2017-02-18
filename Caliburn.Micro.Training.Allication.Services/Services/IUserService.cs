using System.Threading.Tasks;
using Caliburn.Micro.Training.Application.Model;

namespace Caliburn.Micro.Training.Allication.Services.Services
{
    public interface IUserService
    {
        Task<User> FindUser(int userId);
    }
}
