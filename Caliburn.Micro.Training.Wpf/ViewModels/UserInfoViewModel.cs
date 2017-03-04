using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using Caliburn.Micro.Training.Domain.Model;
using Caliburn.Micro.Training.Domain.Services.Services;
using Caliburn.Micro.Training.Domain.Services.Validators;
using Caliburn.Micro.Training.Wpf.Services;
using Microsoft.Win32;

namespace Caliburn.Micro.Training.Wpf.ViewModels
{
    public class UserInfoViewModel : Screen, IDataErrorInfo
    {
        private User _currentUser;
        private readonly UserValidator _userValidator;
        private readonly IUserService _userService;
        private readonly INavigationService _navigationService;

        public UserInfoViewModel(User user, UserValidator userValidator, IUserService userService, INavigationService navigationService)
        {
            _navigationService = navigationService;
            _userService = userService;
            _currentUser = user;
            _userValidator = userValidator;
        }

        #region Fields
        protected User CurrentUser
        {
            get
            {
                return _currentUser;
            }
            set
            {
                _currentUser = value;
                NotifyOfPropertyChange(nameof(CanSave));
            }
        }

        public string FirstName
        {
            get { return CurrentUser.FirstName; }
            set
            {
                CurrentUser.FirstName = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(CanSave));
            }
        }

        public string LastName
        {
            get { return CurrentUser.LastName; }
            set
            {
                CurrentUser.LastName = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(CanSave));
            }
        }

        public DateTime DateOfBirth
        {
            get { return CurrentUser.DateOfBirth; }
            set
            {
                CurrentUser.DateOfBirth = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(CanSave));
            }
        }

        public string Email
        {
            get { return CurrentUser.Email; }
            set
            {
                CurrentUser.Email = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(CanSave));
            }
        }

        public string PhotoPath
        {
            get { return CurrentUser.PhotoPath; }
            set
            {
                CurrentUser.PhotoPath = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(CanSave));
            }
        }
        #endregion

        #region Commands
        public bool IsValid()
        {
            var validationResult = _userValidator.Validate(CurrentUser);
            return validationResult.IsValid;
        }

        public void Cancel()
        {
            _navigationService.Navigate<UsersListViewModel>();
        }

        public bool CanSave
        {
            get { return IsValid(); }
        }
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
            openFileDialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|Portable Network Graphic (*.png)|*.png";
            if (openFileDialog.ShowDialog() == true)
            {
                if (File.Exists(openFileDialog.FileName))
                {
                    PhotoPath = openFileDialog.FileName;
                }
            }
        }
        #endregion

        #region IDataErrorInfo
        public string this[string propertyName]
        {
            get
            {
                string propertyErrorMessage = string.Empty;
                var validationResult = _userValidator.Validate(CurrentUser);
                if (validationResult != null && validationResult.Errors?.Any() == true)
                {
                    var propertyError = validationResult.Errors.FirstOrDefault(error => error.PropertyName == propertyName);
                    if (propertyError != null)
                    {
                        propertyErrorMessage = propertyError.ErrorMessage;
                    }
                }
                return propertyErrorMessage;
            }
        }

        public string Error
        {
            get
            {
                var validationResult = _userValidator.Validate(CurrentUser);
                if (validationResult != null && validationResult.Errors?.Any() == true)
                {
                    var errors = string.Join(Environment.NewLine, validationResult.Errors.Select(x => x.ErrorMessage));
                    return errors;
                }
                return string.Empty;
            }
        }
        #endregion

        #region INotifyPropertyChanged
        public override event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
