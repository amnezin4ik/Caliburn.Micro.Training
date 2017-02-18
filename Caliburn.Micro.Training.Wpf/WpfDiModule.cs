using Autofac;
using Caliburn.Micro.Training.Wpf.ViewModels;

namespace Caliburn.Micro.Training.Wpf
{
    public class WpfDiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MainWindowViewModel>().AsSelf();
        }
    }
}
