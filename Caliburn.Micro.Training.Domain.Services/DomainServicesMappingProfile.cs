using AutoMapper;
using Caliburn.Micro.Training.Domain.Model;
using Caliburn.Micro.Training.Domain.Services.Converters;
using Dto = Caliburn.Micro.Training.Infrastructure.Dto;

namespace Caliburn.Micro.Training.Domain.Services
{
    public class DomainServicesMappingProfile : Profile
    {
        public DomainServicesMappingProfile()
        {
            CreateMap<Dto.User, User>().ConvertUsing<UserConverter>();//.PreserveReferences();
        }
    }
}
