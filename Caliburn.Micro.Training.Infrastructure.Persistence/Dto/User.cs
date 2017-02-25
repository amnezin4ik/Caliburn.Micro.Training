using System;

namespace Caliburn.Micro.Training.Infrastructure.Dto
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PhotoPath { get; set; }
    }
}
