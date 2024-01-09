namespace ISAProject.Modules.Stakeholders.API.Dtos
{
    public class EmployeeRegistrationDto: UserDto
    {
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Profession { get; set; }
        public string CompanyInformation { get; set; }
    }
}
