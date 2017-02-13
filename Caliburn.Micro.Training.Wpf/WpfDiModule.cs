using Autofac;
using Caliburn.Micro.Training.Wpf.Validation;
using Caliburn.Micro.Training.Wpf.ViewModels.MainWindow;

namespace Caliburn.Micro.Training.Wpf
{
    public class WpfDiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MainWindowViewModel>().AsSelf();
            builder.RegisterType<MainWindowValidator>().AsSelf().SingleInstance();
        }
    }
}
