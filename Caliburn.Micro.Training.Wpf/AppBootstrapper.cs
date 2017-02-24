using System.Windows;
using Autofac;
using AutoMapper;
using Caliburn.Micro.Autofac;
using Caliburn.Micro.Training.Domain;
using Caliburn.Micro.Training.Domain.Services;
using Caliburn.Micro.Training.Infrastructure;
using Caliburn.Micro.Training.Wpf.ViewModels;

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
            builder.RegisterModule<DomainDiModule>();
            builder.RegisterModule<InfrastructureDiModule>();
            builder.RegisterModule<DomainServicesDiModule>();
            RegisterAutomapperConfiguration(builder);
        }

        private void RegisterAutomapperConfiguration(ContainerBuilder builder)
        {
            builder.Register(ctx => new MapperConfiguration(cfg =>
            {
                cfg.ConstructServicesUsing(Container.Resolve);
                cfg.AddProfile(typeof(DomainServicesMappingProfile));
            }));
            builder.Register(ctx => ctx.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>();
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
