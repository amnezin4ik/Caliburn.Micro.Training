using Caliburn.Micro.Training.Domain.Model;
using FluentValidation;

namespace Caliburn.Micro.Training.Domain.Validation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user.FirstName)
                .NotEmpty().WithMessage("Please Specify a last name.");
            RuleFor(user => user.LastName)
                .NotEmpty().WithMessage("Please Specify a last name.");
            RuleFor(user => user.Email)
                .NotEmpty().WithMessage("Please Specify an e-mail address.")
                .EmailAddress().WithMessage("Invalid e-mail address");
            //.MustAsync().WithMessage("E-mail address must be unique");
            RuleFor(user => user.PhotoPath)
                .NotEmpty().WithMessage("Please choose a photo.");
        }
    }
}
