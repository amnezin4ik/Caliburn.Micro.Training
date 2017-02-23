using Caliburn.Micro.Training.Wpf.Services;

namespace Caliburn.Micro.Training.Wpf.ViewModels
{
    public class UserInfoViewModel : Screen
    {
        private readonly NavigationService _navigationService;

        public UserInfoViewModel(NavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
