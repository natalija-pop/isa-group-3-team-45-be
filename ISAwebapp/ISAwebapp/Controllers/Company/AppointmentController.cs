using ISAProject.Modules.Company.API.Dtos;
using ISAProject.Modules.Company.API.Public;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Company
{
    [Route("api/appointment")]
    public class AppointmentController : BaseApiController
    { 
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService service)
        {
            _appointmentService = service;
        }
        
        [HttpPost]
        public ActionResult<AppointmentDto> Create([FromBody] AppointmentDto appointmentDto)
        {
            var result = _appointmentService.Create(appointmentDto);
            return CreateResponse(result);
        }

        [HttpGet("getAll")]
        public ActionResult<AppointmentDto> GetAll()
        {
            return CreateResponse(_appointmentService.GetAll());
        }

        [HttpGet("get/{appointmentId:int}")]
        public ActionResult<AppointmentDto> Get([FromRoute] int appointmentId)
        {
            return CreateResponse(_appointmentService.Get(appointmentId));
        }

        [HttpPut("{appointmentId:int}")]
        public ActionResult<AppointmentDto> Update([FromBody] AppointmentDto appointmentDto)
        {
            return CreateResponse(_appointmentService.Update(appointmentDto));
        }

        [HttpGet("getRecommendedAppointments")]
        public ActionResult<AppointmentDto> GetRecommendedAppointments([FromQuery] DateTime selectedDate, [FromQuery] int companyId)
        {
            return CreateResponse(_appointmentService.GenerateRecommendedAppointments(selectedDate, companyId));
        }

    }
}
