using System;
using System.ComponentModel;
using System.Linq;
using FluentValidation;

namespace Caliburn.Micro.Training.Application.ViewModels
{
    public abstract class BaseValidatedViewModel : PropertyChangedBase, IDataErrorInfo
    {
        protected readonly IValidator _validator;
        protected BaseValidatedViewModel(IValidator validator)
        {
            _validator = validator;
        }

        public string this[string propertyName]
        {
            get
            {
                string propertyErrorMessage = String.Empty;
                var validationResult = _validator.Validate(this);
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
                var validationResult = _validator.Validate(this);
                if (validationResult != null && validationResult.Errors?.Any() == true)
                {
                    var errors = string.Join(Environment.NewLine, validationResult.Errors.Select(x => x.ErrorMessage));
                    return errors;
                }
                return string.Empty;
            }
        }
    }
}
