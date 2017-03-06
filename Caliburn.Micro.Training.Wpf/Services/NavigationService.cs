using System;
using System.Collections.Generic;
using Autofac;

namespace Caliburn.Micro.Training.Wpf.Services
{
    public class NavigationService : INavigationService
    {
        private readonly ILifetimeScope _diContainer;
        private readonly IWindowManager _windowManager;
        private IConductor _conductor;

        public NavigationService(ILifetimeScope diContainer, IWindowManager windowManager)
        {
            _diContainer = diContainer;
            _windowManager = windowManager;
        }

        public void Initialize(IConductor conductor)
        {
            _conductor = conductor;
        }

        public void Navigate<T>(params object[] parameters) where T : IScreen
        {
            if (_conductor == null)
            {
                throw new InvalidOperationException("You should initialize this service before use it");
            }

            List<global::Autofac.Core.Parameter> typedParameters = new List<global::Autofac.Core.Parameter>();
            foreach (var parameter in parameters)
            {
                var typedParameter = new TypedParameter(parameter.GetType(), parameter);
                typedParameters.Add(typedParameter);
            }

            var screen = (IScreen)_diContainer.Resolve(typeof(T), typedParameters);
            _conductor.ActivateItem(screen);
        }
    }
}
