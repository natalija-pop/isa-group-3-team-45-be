using ISAProject.Configuration.Core.Domain;

namespace ISAProject.Modules.Stakeholders.Core.Domain
{
    public class User : Entity
    {
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }
        public string Phone { get; private set; }
        public string Profession { get; private set; }
        public string CompanyInformation { get; private set; }
        public UserRole Role { get; private set; }
        public bool IsActivated { get; private set; } = false;
        public bool ForcePasswordReset { get; private set; } 

        public User() {}

        public User(string email, string password, string name, string surname, string city, string country, string phone, string profession, string companyInformation, UserRole role, bool isActivated)
        {
            Email = email;
            Password = password;
            Name = name;
            Surname = surname;
            City = city;
            Country = country;
            Phone = phone;
            Profession = profession;
            CompanyInformation = companyInformation;
            Role = role;
            IsActivated = isActivated;
            ForcePasswordReset = role == UserRole.SystemAdministrator;
            Validate();
        }
        private void Validate()
        {
            if (string.IsNullOrWhiteSpace(Email)) throw new ArgumentException("Invalid Email");
            if (string.IsNullOrWhiteSpace(Password)) throw new ArgumentException("Invalid Password");
            if (string.IsNullOrWhiteSpace(Name)) throw new ArgumentException("Invalid Name");
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

        public bool ChangePassword(string newPassword)
        {
            //TODO: Napraviti bolju validaciju lozinke
            if (string.IsNullOrWhiteSpace(newPassword)) return false;
            Password = newPassword;
            if (ForcePasswordReset && Role == UserRole.SystemAdministrator) ForcePasswordReset = false;
            return true;
        }

    }
    public enum UserRole
    {
        Employee,
        CompanyAdministrator,
        SystemAdministrator
    }
}
