using System.ComponentModel;
using System.IO;
using Caliburn.Micro.Training.Domain.Model;
using Caliburn.Micro.Training.Domain.Services.Services;
using Caliburn.Micro.Training.Wpf.Services;
using Microsoft.Win32;

namespace Caliburn.Micro.Training.Wpf.ViewModels
{
    public class UserInfoViewModel : Screen, IDataErrorInfo
    {
        private User _currentUser;
        private readonly IUserService _userService;
        private readonly INavigationService _navigationService;

        public UserInfoViewModel(User currentUser, IUserService userService, INavigationService navigationService)
        {
            _navigationService = navigationService;
            _currentUser = currentUser;
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
                //NotifyOfPropertyChange(nameof(CanSave));
            }
        }
        
        public void Cancel()
        {
            _navigationService.Navigate<UsersListViewModel>();
        }

        //public bool CanSave
        //{
        //    get { return CurrentUser.IsValid(); }
        //}
        public async void Save()
        {
            if (CurrentUser.Id > 0)
            {
                await _userService.UpdateUserAsync(CurrentUser);
            }
            else
            {
                await _userService.AddUserAsync(CurrentUser);
            }
            _navigationService.Navigate<UsersListViewModel>();
        }

        public void SelectPhoto()
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select a photo";
            openFileDialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (openFileDialog.ShowDialog() == true)
            {
                if (File.Exists(openFileDialog.FileName))
                {
                    CurrentUser.PhotoPath = openFileDialog.FileName;
                }
            }
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
