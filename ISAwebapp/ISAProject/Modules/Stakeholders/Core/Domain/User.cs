using ISAProject.Configuration.Core.Domain;

namespace ISAProject.Modules.Stakeholders.Core.Domain
{
    public class User : Entity
    {
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public UserRole Role { get; private set; }
        public bool IsActivated { get; private set; } = false;
        public bool ForcePasswordReset { get; private set; } 
        public int PenaltyPoints { get;  set; }
        public DateTime DeletionPenaltyDate { get;  set; }

        public User() {}

        public User(string email, string password, string name, string surname, UserRole role, bool isActivated)
        {
            Email = email;
            Password = password;
            Name = name;
            Surname = surname;
            Role = role;
            IsActivated = isActivated;
            PenaltyPoints = 0;
            DeletionPenaltyDate = DateTime.Now;
            ForcePasswordReset = (role == UserRole.SystemAdministrator || role == UserRole.CompanyAdministrator);
            Validate();
        }
        private void Validate()
        {
            if (string.IsNullOrWhiteSpace(Email)) throw new ArgumentException("Invalid Email");
            if (string.IsNullOrWhiteSpace(Password)) throw new ArgumentException("Invalid Password");
            if (string.IsNullOrWhiteSpace(Name)) throw new ArgumentException("Invalid Name");
            if (string.IsNullOrWhiteSpace(Surname)) throw new ArgumentException("Invalid Surname");
        }

        public string GetPrimaryRoleName()
        {
            return Role.ToString().ToLower();
        }

        public bool ChangePassword(string newPassword)
        {
            //TODO: Napraviti bolju validaciju lozinke
            if (string.IsNullOrWhiteSpace(newPassword) && Password.Equals(newPassword)) return false;
            Password = newPassword;
            if (ForcePasswordReset && (Role == UserRole.SystemAdministrator || Role == UserRole.CompanyAdministrator)) ForcePasswordReset = false;
            return true;
        }

        public void GetPenaltyPoints()
        {
            PenaltyPoints+= -2;
        }
    }
    public enum UserRole
    {
        Employee,
        CompanyAdministrator,
        SystemAdministrator
    }
}
