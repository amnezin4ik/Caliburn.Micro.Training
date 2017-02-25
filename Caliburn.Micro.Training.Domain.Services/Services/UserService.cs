using System.Collections.Generic;
using System.IO;
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

        public async Task<User> FindUserAsync(int userId)
        {
            var userDto = await _userRepository.GetAsync(userId);
            var user = _mapper.Map<Dto.User, User>(userDto);
            return user;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            var userDtos = await _userRepository.GetAllAsync();
            var users = _mapper.Map<IEnumerable<Dto.User>, IEnumerable<User>>(userDtos);
            return users;
        }

        public async Task DeleteUserAsync(int userId)
        {
            await _userRepository.DeleteAsync(userId);
        }

        public async Task AddUserAsync(User user)
        {
            if (user.IsValid() == false)
            {
                throw new InvalidDataException("user must be valid");
            }
            var userDto = _mapper.Map<User, Dto.User>(user);
            await _userRepository.CreateAsync(userDto);
        }

        public async Task UpdateUserAsync(User user)
        {
            if (user.IsValid() == false)
            {
                throw new InvalidDataException("user must be valid");
            }
            var userDto = _mapper.Map<User, Dto.User>(user);
            await _userRepository.UpdateAsync(userDto);
        }
    }
}
