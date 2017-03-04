using System.Collections.ObjectModel;
using Autofac;
using Caliburn.Micro.Training.Domain.Model;
using Caliburn.Micro.Training.Domain.Services.Services;
using Caliburn.Micro.Training.Wpf.Services;

namespace Caliburn.Micro.Training.Wpf.ViewModels
{
    public class UsersListViewModel : Screen
    {
        private readonly IUserService _userService;
        private readonly INavigationService _navigationService;

        public UsersListViewModel(IUserService userService, INavigationService navigationService)
        {
            _userService = userService;
            _navigationService = navigationService;
        }

        private ObservableCollection<User> _users;
        public ObservableCollection<User> Users
        {
            get { return _users; }
            set
            {
                _users = value;
                NotifyOfPropertyChange();
            }
        }

        private User _selectedUser;
        public User SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                _selectedUser = value;
                NotifyOfPropertyChange();
                NotifyOfPropertyChange(nameof(CanEditUser));
                NotifyOfPropertyChange(nameof(CanDeleteUser));
            }
        }

        public void AddUser()
        {
            _navigationService.Navigate<UserInfoViewModel>(new User());
        }

        public bool CanEditUser
        {
            get { return SelectedUser != null; }
        }
        public void EditUser()
        {
            _navigationService.Navigate<UserInfoViewModel>(SelectedUser);
        }

        public bool CanDeleteUser
        {
            get { return SelectedUser != null; }
        }
        public async void DeleteUser()
        {
            await _userService.DeleteUserAsync(SelectedUser.Id);
            Users.Remove(SelectedUser);
        }

        protected override async void OnInitialize()
        {
            var allUsers = await _userService.GetAllUsersAsync();
            Users = new ObservableCollection<User>(allUsers);
        }
    }
}
