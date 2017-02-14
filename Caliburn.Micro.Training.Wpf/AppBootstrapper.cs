using System.Windows;
using Autofac;
using Caliburn.Micro.Autofac;
using Caliburn.Micro.Training.Allication.Services;
using Caliburn.Micro.Training.Application;
using Caliburn.Micro.Training.Infrastructure;
using Caliburn.Micro.Training.Wpf.ViewModels.MainWindow;

namespace Caliburn.Micro.Training.Wpf
{
    public class AppBootstrapper : AutofacBootstrapper<MainWindowViewModel>
    {
        public AppBootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<MainWindowViewModel>();
        }

        protected override void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<WpfDiModule>();
            builder.RegisterModule<ApplicationDiModule>();
            builder.RegisterModule<InfrastructureDiModule>();
            builder.RegisterModule<ApplicationServicesDiModule>();
        }

        protected override void ConfigureBootstrapper()
        {
            base.ConfigureBootstrapper();
            var config = new TypeMappingConfiguration
            {
                DefaultSubNamespaceForViews = "Caliburn.Micro.Training.Wpf.Views",
                DefaultSubNamespaceForViewModels = "Caliburn.Micro.Training.Wpf.ViewModels"
            };
            ViewLocator.ConfigureTypeMappings(config);
            ViewModelLocator.ConfigureTypeMappings(config);
        }
    }
}
