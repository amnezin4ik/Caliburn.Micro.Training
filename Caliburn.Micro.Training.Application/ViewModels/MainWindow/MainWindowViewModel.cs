using Caliburn.Micro.Training.Application.Validation;

namespace Caliburn.Micro.Training.Application.ViewModels.MainWindow
{
    public class MainWindowViewModel : BaseValidatedViewModel
    {
        public MainWindowViewModel(MainWindowValidator validator) 
            : base(validator)
        {
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
    }
}
