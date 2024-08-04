using System;

namespace DesktopInformationSystem
{
    public class Person
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }

        // Constructor with all parameters
        public Person(string name, string gender, string email, string phone, string role, string status)
        {
            Name = name;
            Gender = gender;
            Email = email;
            Phone = phone;
            Role = role;
            Status = status;
        }

        // Parameterless constructor
        public Person()
        {
        }

        // Method to display information
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name}, Gender: {Gender}, Email: {Email}, Phone: {Phone}, Role: {Role}, Status: {Status}");
        }
    }
}
