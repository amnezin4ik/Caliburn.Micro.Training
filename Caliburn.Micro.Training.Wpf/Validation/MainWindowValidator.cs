using Caliburn.Micro.Training.Wpf.ViewModels.MainWindow;
using FluentValidation;

namespace Caliburn.Micro.Training.Wpf.Validation
{
    public class MainWindowValidator : AbstractValidator<MainWindowViewModel>
    {
        public MainWindowValidator()
        {
            RuleFor(user => user.Name)
                .NotEmpty()
                .WithMessage("Please Specify a Name.");
        }
    }
}
