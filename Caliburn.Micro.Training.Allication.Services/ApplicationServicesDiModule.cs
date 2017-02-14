using Autofac;
using Caliburn.Micro.Training.Allication.Services.Services;

namespace Caliburn.Micro.Training.Allication.Services
{
    public class ApplicationServicesDiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserService>().AsImplementedInterfaces();
        }
    }
}
