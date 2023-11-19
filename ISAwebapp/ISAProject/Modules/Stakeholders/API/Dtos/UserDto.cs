using ISAProject.Modules.Stakeholders.Core.Domain;

namespace ISAProject.Modules.Stakeholders.API.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Profession { get; set; }
        public string CompanyInformation { get; set; }
        public UserRole Role { get; set; }
        public bool IsActivated { get; set; }
    }
}
