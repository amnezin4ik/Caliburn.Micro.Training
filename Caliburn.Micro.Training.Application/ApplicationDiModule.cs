using Autofac;
using Caliburn.Micro.Training.Application.Validation;

namespace Caliburn.Micro.Training.Application
{
    public class ApplicationDiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserValidator>().AsSelf();
        }
    }
}
