using AutoMapper;
using Caliburn.Micro.Training.Domain.Model;
using Dto = Caliburn.Micro.Training.Infrastructure.Dto;

namespace Caliburn.Micro.Training.Domain.Services
{
    public class DomainServicesMappingProfile : Profile
    {
        public DomainServicesMappingProfile()
        {
            CreateMap<Dto.User, User>().PreserveReferences();
            CreateMap<User, Dto.User>().PreserveReferences();
        }
    }
}
