using System;
using Autofac;

namespace Caliburn.Micro.Training.Wpf.Services
{
    public class NavigationService
    {
        private bool _isInitialized;
        private readonly ILifetimeScope _container;
        private Conductor<IScreen> _conductorWindow;

        public NavigationService(ILifetimeScope container)
        {
            _container = container;
            _isInitialized = false;
        }

        public void Initialize(Conductor<IScreen> conductorWindow)
        {
            _conductorWindow = conductorWindow;
            _isInitialized = true;
        }

        public void Navigate<T>() where T : IScreen
        {
            if (_isInitialized == false)
            {
                throw new Exception("You should initialize this service before use it");
            }
            var screen = (IScreen)_container.Resolve(typeof(T));
            _conductorWindow.ActivateItem(screen);
        }
    }
}
