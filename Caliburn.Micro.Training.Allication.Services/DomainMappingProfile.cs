using AutoMapper;
using Caliburn.Micro.Training.Application.Model;
using Caliburn.Micro.Training.Application.Validation;
using Dto = Caliburn.Micro.Training.Infrastructure.Dto;

namespace Caliburn.Micro.Training.Allication.Services
{
    public class DomainMappingProfile : Profile
    {
        public DomainMappingProfile()
        {
            CreateMap<Dto.User, User>().ConvertUsing<UserConverter>();
        }
    }

    public class UserConverter : ITypeConverter<Dto.User, User>
    {
        private readonly UserValidator _userValidator;

        public UserConverter(UserValidator userValidator)
        {
            _userValidator = userValidator;
        }

        public User Convert(Dto.User source, User destination, ResolutionContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}
