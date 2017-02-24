using Autofac;
using Caliburn.Micro.Training.Domain.Services.Services;

namespace Caliburn.Micro.Training.Domain.Services
{
    public class DomainServicesDiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserService>().AsImplementedInterfaces();
        }
    }
}
