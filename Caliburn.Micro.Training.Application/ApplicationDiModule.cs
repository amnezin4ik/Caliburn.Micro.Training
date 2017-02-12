using Autofac;
using Caliburn.Micro.Training.Application.Validation;
using Caliburn.Micro.Training.Application.ViewModels.MainWindow;

namespace Caliburn.Micro.Training.Application
{
    public class ApplicationDiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MainWindowValidator>().AsSelf().SingleInstance();

            builder.RegisterType<MainWindowViewModel>().AsSelf();
        }
    }
}
