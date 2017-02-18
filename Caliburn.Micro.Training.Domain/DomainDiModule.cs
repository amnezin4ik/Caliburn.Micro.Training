using Autofac;
using Caliburn.Micro.Training.Domain.Validation;

namespace Caliburn.Micro.Training.Domain
{
    public class DomainDiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserValidator>().AsSelf();
        }
    }
}
