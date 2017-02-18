using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using FluentValidation;

namespace Caliburn.Micro.Training.Domain.Model
{
    public abstract class ModelBase : INotifyPropertyChanged, IDataErrorInfo
    {
        private readonly IValidator _validator;
        protected ModelBase(IValidator validator)
        {
            _validator = validator;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region IDataErrorInfo
        public string this[string propertyName]
        {
            get
            {
                string propertyErrorMessage = string.Empty;
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
        #endregion
    }
}
