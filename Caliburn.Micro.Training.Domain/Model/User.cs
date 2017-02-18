using System;
using Caliburn.Micro.Training.Domain.Validation;

namespace Caliburn.Micro.Training.Domain.Model
{
    public class User : ModelBase
    {
        private int _id;
        private string _firstName;
        private string _lastName;
        private DateTime _dateOfBirth;
        private string _email;

        public User(UserValidator validator)
            : base(validator) { }

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }

        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set
            {
                _dateOfBirth = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }
    }
}
