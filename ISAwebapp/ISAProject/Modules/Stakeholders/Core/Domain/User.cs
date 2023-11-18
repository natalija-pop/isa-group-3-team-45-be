using ISAProject.Configuration.Core.Domain;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace ISAProject.Modules.Stakeholders.Core.Domain
{
    public class User : Entity
    {
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Username { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }
        public string Phone { get; private set; }
        public string Profession { get; private set; }
        public string CompanyInformation { get; private set; }
        public UserRole Role { get; private set; }
        public bool IsActivated { get; private set; } = false;

        public User(string email,string username, string password, string name, string surname, string city, string country, string phone, string profession, string companyInformation, UserRole role, bool isActivated)
        {
            Email = email;
            Password = password;
            Username = username;
            Name = name;
            Surname = surname;
            City = city;
            Country = country;
            Phone = phone;
            Profession = profession;
            CompanyInformation = companyInformation;
            Role = role;
            IsActivated = isActivated;
            Validate();
        }
        private void Validate()
        {
            if (string.IsNullOrWhiteSpace(Email)) throw new ArgumentException("Invalid Email");
            if (string.IsNullOrWhiteSpace(Password)) throw new ArgumentException("Invalid Password");
            if (string.IsNullOrWhiteSpace(Name)) throw new ArgumentException("Invalid Name");
            if (string.IsNullOrWhiteSpace(Username)) throw new ArgumentException("Invalid Name");
            if (string.IsNullOrWhiteSpace(Surname)) throw new ArgumentException("Invalid Surname");
            if (string.IsNullOrWhiteSpace(City)) throw new ArgumentException("Invalid City");
            if (string.IsNullOrWhiteSpace(Country)) throw new ArgumentException("Invalid Country");
            if (string.IsNullOrWhiteSpace(Phone)) throw new ArgumentException("Invalid Phone");
            if (string.IsNullOrWhiteSpace(Profession)) throw new ArgumentException("Invalid Profession");
            if (string.IsNullOrWhiteSpace(CompanyInformation)) throw new ArgumentException("Invalid CompanyInformation");
        }

        public string GetPrimaryRoleName()
        {
            return Role.ToString().ToLower();
        }
    }

    public enum UserRole
    {
        Employee,
        CompanyAdministrator,
        SystemAdministrator
    }
}
