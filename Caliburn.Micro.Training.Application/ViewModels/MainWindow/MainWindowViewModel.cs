using System.Collections.ObjectModel;
using Caliburn.Micro.Training.Application.Validation;
using Caliburn.Micro.Training.Domain;

namespace Caliburn.Micro.Training.Application.ViewModels.MainWindow
{
    public class MainWindowViewModel : BaseValidatedViewModel
    {
        public MainWindowViewModel(MainWindowValidator validator)
            : base(validator)
        {
            UsersCollection = new ObservableCollection<User>
            {
                new User {Name = "Stephen"},
                new User {Name = "Bill"},
                new User {Name = "John"}
            };
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

        public ObservableCollection<User> UsersCollection { get; private set; }
    }
}
