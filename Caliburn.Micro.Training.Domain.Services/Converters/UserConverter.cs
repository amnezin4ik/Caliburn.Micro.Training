using System;
using AutoMapper;
using Caliburn.Micro.Training.Domain.Model;
using Caliburn.Micro.Training.Domain.Validation;

namespace Caliburn.Micro.Training.Domain.Services.Converters
{
    public class UserConverter : ITypeConverter<Infrastructure.Dto.User, User>
    {
        private readonly UserValidator _userValidator;
        private readonly IMapper _mapper;

        public UserConverter(UserValidator userValidator, IMapper mapper)
        {
            _userValidator = userValidator;
            _mapper = mapper;
        }

        public User Convert(Infrastructure.Dto.User source, User destination, ResolutionContext context)
        {
            throw new NotImplementedException();
            if (source == null)
            {
                return null;
            }
            destination = new User(_userValidator);
            _mapper.Map(source, destination);
            return destination;
        }
    }
}
