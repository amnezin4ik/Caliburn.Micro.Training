using System.Collections.ObjectModel;
using Caliburn.Micro.Training.Infrastructure.Dto;
using Caliburn.Micro.Training.Infrastructure.Repository;
using Caliburn.Micro.Training.Wpf.Validation;

namespace Caliburn.Micro.Training.Wpf.ViewModels.MainWindow
{
    public class MainWindowViewModel : BaseValidatedViewModel
    {
        private readonly IUserRepository _userRepository;

        public MainWindowViewModel(MainWindowValidator validator, IUserRepository userRepository)
            : base(validator)
        {
            _userRepository = userRepository;
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                NotifyOfPropertyChange(nameof(Name));
            }
        }

        protected override async void OnActivate()
        {
            var allUsers = await _userRepository.GetAllAsync();
            UsersCollection = new ObservableCollection<User>(allUsers);
        }

        public ObservableCollection<User> UsersCollection { get; protected set; }
    }
}
