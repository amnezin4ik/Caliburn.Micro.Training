using Caliburn.Micro.Training.Application.ViewModels.MainWindow;
using FluentValidation;

namespace Caliburn.Micro.Training.Application.Validation
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
