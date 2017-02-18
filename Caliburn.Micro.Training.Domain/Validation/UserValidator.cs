using Caliburn.Micro.Training.Domain.Model;
using FluentValidation;

namespace Caliburn.Micro.Training.Domain.Validation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user.FirstName)
                .NotEmpty().WithMessage("Please Specify a FirstName.");
            RuleFor(user => user.Email)
                .NotEmpty().WithMessage("Please Specify a Email.")
                .EmailAddress().WithMessage("Invalid Email");
        }
    }
}
