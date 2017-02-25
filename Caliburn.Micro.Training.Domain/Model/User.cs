using System;
using Caliburn.Micro.Training.Domain.Validation;

namespace Caliburn.Micro.Training.Domain.Model
{
    public class User : ModelBase
    {
        public User(UserValidator validator)
            : base(validator) { }

        private int _id;
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }

        private DateTime _dateOfBirth;
        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set
            {
                _dateOfBirth = value;
                OnPropertyChanged();
            }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        private string _photoPath;
        public string PhotoPath
        {
            get { return _photoPath; }
            set
            {
                _photoPath = value;
                OnPropertyChanged();
            }
        }

        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }
    }
}
