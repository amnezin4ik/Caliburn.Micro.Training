using System;
using System.ComponentModel;

namespace Caliburn.Micro.Training.Application.Entity
{
    public class User : IDataErrorInfo
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }

        public string this[string columnName]
        {
            get { throw new NotImplementedException(); }
        }

        public string Error { get; }
    }
}
