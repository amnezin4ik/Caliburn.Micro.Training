using System.ComponentModel;
using Caliburn.Micro.Training.Domain.Model;
using Caliburn.Micro.Training.Domain.Services.Services;
using Caliburn.Micro.Training.Wpf.Services;

namespace Caliburn.Micro.Training.Wpf.ViewModels
{
    public class UsersListViewModel : Screen, IDataErrorInfo
    {
        private User _currentUser;
        private readonly IUserService _userService;
        private readonly INavigationService _navigationService;

        public UsersListViewModel(IUserService userService, INavigationService navigationService)
        {
            _userService = userService;
            _navigationService = navigationService;
        }

        public User CurrentUser
        {
            get
            {
                return _currentUser;
            }
            set
            {
                _currentUser = value;
                NotifyOfPropertyChange();
            }
        }

        public void SimpleButton()
        {
            _navigationService.Navigate<UserInfoViewModel>();
        }

        protected override async void OnInitialize()
        {
            CurrentUser = await _userService.FindUser(1);
        }

        #region IDataErrorInfo
        public string this[string columnName]
        {
            get { return CurrentUser[columnName]; }
        }

        public string Error
        {
            get { return CurrentUser.Error; }
        }
        #endregion
    }
}
