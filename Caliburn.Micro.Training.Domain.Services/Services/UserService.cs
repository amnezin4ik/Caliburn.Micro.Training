using System.Threading.Tasks;
using AutoMapper;
using Caliburn.Micro.Training.Domain.Model;
using Caliburn.Micro.Training.Infrastructure.Repository;
using Dto = Caliburn.Micro.Training.Infrastructure.Dto;

namespace Caliburn.Micro.Training.Domain.Services.Services
{
    internal class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<User> FindUser(int userId)
        {
            var userDto = await _userRepository.GetAsync(userId);
            var user = _mapper.Map<Dto.User, User>(userDto);
            return user;
        }
    }
}
