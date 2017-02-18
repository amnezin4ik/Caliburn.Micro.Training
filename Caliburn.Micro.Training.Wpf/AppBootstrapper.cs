using System.Collections.Generic;
using System.Windows;
using Autofac;
using AutoMapper;
using Caliburn.Micro.Autofac;
using Caliburn.Micro.Training.Domain;
using Caliburn.Micro.Training.Domain.Services;
using Caliburn.Micro.Training.Domain.Services.Services;
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
            //var viewModelSettings = new Dictionary<string, object>();

            //var userService = (IUserService)Container.Resolve(typeof (IUserService));
            //var currentUser = userService.FindUser(1).Result;
            //viewModelSettings.Add("currentUser", currentUser);
            DisplayRootViewFor<MainWindowViewModel>(viewModelSettings);
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
            var config = new MapperConfiguration(cfg =>
            {
                cfg.ConstructServicesUsing(type => Container.Resolve(type));
                cfg.AddProfile(new DomainServicesMappingProfile());
            });
            var mapper = config.CreateMapper();
            builder.RegisterInstance(mapper).As<IMapper>();
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
