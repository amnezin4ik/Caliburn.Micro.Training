using Autofac;
using Caliburn.Micro.Training.Wpf.Services;

namespace Caliburn.Micro.Training.Wpf
{
    public class WpfDiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<NavigationService>().AsImplementedInterfaces().SingleInstance();
        }
    }
}
