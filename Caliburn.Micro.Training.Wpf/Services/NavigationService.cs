using System;
using Autofac;

namespace Caliburn.Micro.Training.Wpf.Services
{
    public class NavigationService : INavigationService
    {
        private bool _isInitialized;
        private readonly ILifetimeScope _diContainer;
        private IConductor _conductor;

        public NavigationService(ILifetimeScope diContainer)
        {
            _diContainer = diContainer;
            _isInitialized = false;
        }

        public void Initialize(IConductor conductor)
        {
            _conductor = conductor;
            _isInitialized = true;
        }

        public void Navigate<T>() where T : IScreen
        {
            if (_isInitialized == false)
            {
                throw new Exception("You should initialize this service before use it");
            }
            var screen = (IScreen)_diContainer.Resolve(typeof(T));
            _conductor.ActivateItem(screen);
        }
    }
}
