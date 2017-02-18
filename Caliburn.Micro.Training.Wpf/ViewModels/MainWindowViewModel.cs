using Caliburn.Micro.Training.Domain.Model;
using Caliburn.Micro.Training.Domain.Services.Services;
using Caliburn.Micro.Training.Domain.Validation;

namespace Caliburn.Micro.Training.Wpf.ViewModels
{
    public class MainWindowViewModel : Screen
    {
        private User _currentUser;
        private readonly IUserService _userService;

        public MainWindowViewModel(IUserService userService, User currentUser)
        {
            _userService = userService;
            _currentUser = currentUser;
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

        //protected override async void OnInitialize()
        //{
        //    base.OnInitialize();
        //    _currentUser = await _userService.FindUser(1);
        //}

        //protected override async void OnActivate()
        //{
        //    _currentUser = await _userService.FindUser(1);
        //}

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
