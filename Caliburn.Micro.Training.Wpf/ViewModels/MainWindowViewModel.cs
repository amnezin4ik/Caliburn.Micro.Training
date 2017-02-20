using System.ComponentModel;
using Caliburn.Micro.Training.Domain.Model;
using Caliburn.Micro.Training.Domain.Services.Services;

namespace Caliburn.Micro.Training.Wpf.ViewModels
{
    public class MainWindowViewModel : Screen, IDataErrorInfo
    {
        private User _currentUser;
        private readonly IUserService _userService;

        public MainWindowViewModel(IUserService userService)
        {
            _userService = userService;
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
