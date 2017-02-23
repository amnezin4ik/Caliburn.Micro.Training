using Caliburn.Micro.Training.Wpf.Services;

namespace Caliburn.Micro.Training.Wpf.ViewModels
{
    public class MainWindowViewModel : Conductor<IScreen>
    {
        private readonly NavigationService _navigationService;

        public MainWindowViewModel(NavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        protected override void OnInitialize()
        {
            _navigationService.Initialize(this);
            _navigationService.Navigate<UsersListViewModel>();
        }
    }
}
