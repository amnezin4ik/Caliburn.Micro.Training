using Autofac;
using Caliburn.Micro.Training.Domain.Services.Services;
using Caliburn.Micro.Training.Domain.Services.Validators;

namespace Caliburn.Micro.Training.Domain.Services
{
    public class DomainServicesDiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserService>().AsImplementedInterfaces();
            builder.RegisterType<UserValidator>().AsSelf();
        }
    }
}
