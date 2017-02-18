using System.ComponentModel;
using Caliburn.Micro.Training.Domain.Model;
using Caliburn.Micro.Training.Domain.Services.Services;
using Caliburn.Micro.Training.Domain.Validation;

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

        public string FirstName
        {
            get
            {
                return _currentUser.FirstName;
            }
            set
            {
                _currentUser.FirstName = value;
                NotifyOfPropertyChange();
            }
        }

        protected override async void OnInitialize()
        {
            base.OnInitialize();
            _currentUser = new User(new UserValidator());
        }

        #region IDataErrorInfo
        public string this[string columnName]
        {
            get { return _currentUser[columnName]; }
        }

        public string Error
        {
            get { return _currentUser.Error; }
        }
        #endregion
    }
}
