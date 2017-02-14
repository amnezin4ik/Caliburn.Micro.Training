using System.ComponentModel;
using Caliburn.Micro.Training.Allication.Services.Services;
using Caliburn.Micro.Training.Application.Entity;

namespace Caliburn.Micro.Training.Wpf.ViewModels.MainWindow
{
    public class MainWindowViewModel : Screen, IDataErrorInfo//BaseValidatedViewModel
    {
        private readonly IUserService _userService;

        public MainWindowViewModel(IUserService userService)
        {
            _userService = userService;
        }

        private User _currentUser;


        public string FirstName
        {
            get { return _currentUser.FirstName; }
            set
            {
                _currentUser.FirstName = value;
                NotifyOfPropertyChange(nameof(FirstName));
            }
        }

        protected override async void OnActivate()
        {
            _currentUser = await _userService.FindUser(1);
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
