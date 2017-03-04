using System;
using Caliburn.Micro.Training.Common;
using Caliburn.Micro.Training.Domain.Model;
using Caliburn.Micro.Training.Domain.Services.Services;
using FluentValidation;

namespace Caliburn.Micro.Training.Domain.Services.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator(IDateTimeProvider dateTimeProvider, IUserService userService)
        {
            RuleFor(user => user.FirstName)
                .NotEmpty().WithMessage("Please Specify a first name.");

            RuleFor(user => user.LastName)
                .NotEmpty().WithMessage("Please Specify a last name.");

            RuleFor(user => user.Email)
                .NotEmpty().WithMessage("Please Specify an e-mail address.")
                .EmailAddress().WithMessage("Invalid e-mail address")
                //.MustAsync((email, token) => userService.IsUserEmailUniqueAsync(email)).WithMessage("E-mail address must be unique")
                ;

            RuleFor(user => user.DateOfBirth)
                .NotEmpty().WithMessage("Please choose a DateOfBirth.")
                .Must((user, dateOfBirth) => IsDateOfBirthValid(dateTimeProvider, dateOfBirth)).WithMessage("Please choose valid date.");

            RuleFor(user => user.PhotoPath)
                .NotEmpty().WithMessage("Please choose a photo.");
        }

        private bool IsDateOfBirthValid(IDateTimeProvider dateTimeProvider, DateTime dateOfBirth)
        {
            return dateOfBirth >= dateTimeProvider.GetUtcNow().AddYears(-150) && dateOfBirth <= dateTimeProvider.GetUtcNow();
        }
    }
}
