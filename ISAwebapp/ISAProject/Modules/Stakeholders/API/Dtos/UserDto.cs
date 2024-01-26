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
        public UserRole Role { get; set; }
        public bool IsActivated { get; set; }
        public int PenaltyPoints {  get; set; }
    }
}
