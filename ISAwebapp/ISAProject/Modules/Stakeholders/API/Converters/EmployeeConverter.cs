using ISAProject.Modules.Stakeholders.API.Dtos;
using ISAProject.Modules.Stakeholders.Core.Domain;

namespace ISAProject.Modules.Stakeholders.API.Converters
{
    public static class EmployeeConverter
    {
        public static EmployeeRegistrationDto ConvertToDto(Employee employee)
        {
            return new EmployeeRegistrationDto
            {
                Id = (int)employee.Id,
                Email = employee.Email,
                Password = employee.Password,
                Name = employee.Name,
                Surname = employee.Surname,
                Role = employee.Role,
                IsActivated = employee.IsActivated,
                City = employee.City,
                Country = employee.Country,
                CompanyInformation = employee.CompanyInformation,
                Phone = employee.Phone,
                Profession = employee.Profession
            };
        }
    }
}
