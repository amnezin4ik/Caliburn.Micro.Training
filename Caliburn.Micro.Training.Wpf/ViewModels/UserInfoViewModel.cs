using Caliburn.Micro.Training.Wpf.Services;

namespace Caliburn.Micro.Training.Wpf.ViewModels
{
    public class UserInfoViewModel : Screen
    {
        private readonly INavigationService _navigationService;

        public UserInfoViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
