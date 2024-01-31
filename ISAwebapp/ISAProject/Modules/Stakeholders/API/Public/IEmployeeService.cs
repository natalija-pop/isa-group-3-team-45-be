using FluentResults;
using ISAProject.Modules.Stakeholders.API.Dtos;

namespace ISAProject.Modules.Stakeholders.API.Public
{
    public interface IEmployeeService
    {
        Result<EmployeeRegistrationDto> Get(int id);
        Result<EmployeeRegistrationDto> Update(EmployeeRegistrationDto employee);
    }
}
