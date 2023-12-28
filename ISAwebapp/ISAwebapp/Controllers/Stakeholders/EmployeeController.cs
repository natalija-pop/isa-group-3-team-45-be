using ISAProject.Modules.Stakeholders.API.Dtos;
using ISAProject.Modules.Stakeholders.API.Public;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Stakeholders
{
    [Route(("api/employee"))]
    public class EmployeeController: BaseApiController
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("get-profile/{employeeId:int}")]
        public ActionResult<EmployeeRegistrationDto> Get([FromRoute] int employeeId)
        {
            return CreateResponse(_employeeService.Get(employeeId));
        }

        [HttpPut("update-profile")]
        public ActionResult<EmployeeRegistrationDto> Update([FromBody] EmployeeRegistrationDto employeeRegistrationDto)
        {
            return CreateResponse(_employeeService.Update(employeeRegistrationDto));
        }
    }
}