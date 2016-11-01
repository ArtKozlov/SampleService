using System;

namespace DAL
{
    public class User
    {
        public User() { }

        public User(string firstname, string lastName, DateTime dateOfBirth)
        {
            FirstName = firstname;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
