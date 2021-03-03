using System;

namespace Model
{
    public class Patient
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public Patient(int id, string firstName, string lastName, DateTime dateOfBirth, string phone, string address)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Phone = phone;
            Address = address;
        }

        public Patient(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public Patient()
        {

        }
    }
}
