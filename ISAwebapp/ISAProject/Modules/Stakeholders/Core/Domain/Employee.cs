using static System.Text.RegularExpressions.Regex;
namespace ISAProject.Modules.Stakeholders.Core.Domain
{
    public class Employee : User
    {
        public string City { get; private set; }
        public string Country { get; private set; }
        public string Phone { get; private set; }
        public string Profession { get; private set; }
        public string CompanyInformation { get; private set; }

        public Employee()
        {
        }

        public Employee(string city, string country, string phone, string profession, string companyInformation, string email, string password, string name, string surname, UserRole role, bool isActivated) : base(email, password, name, surname, role, isActivated)
        {
            Validate(city, country, phone, profession, companyInformation);
            City = city;
            Country = country;
            Phone = phone;
            Profession = profession;
            CompanyInformation = companyInformation;
        }

        private void Validate(string city, string country, string phone, string profession, string companyInformation)
        {
            if (string.IsNullOrWhiteSpace(city)) throw new ArgumentException("Invalid City");
            if (string.IsNullOrWhiteSpace(country)) throw new ArgumentException("Invalid Country");
            if (string.IsNullOrWhiteSpace(phone) || !IsMatch(phone, @"^\d+$")) throw new ArgumentException("Invalid Phone, phone contains only digits");
            if (string.IsNullOrWhiteSpace(profession)) throw new ArgumentException("Invalid Profession");
            if (string.IsNullOrWhiteSpace(companyInformation)) throw new ArgumentException("Invalid CompanyInformation");
        }
    }
}
