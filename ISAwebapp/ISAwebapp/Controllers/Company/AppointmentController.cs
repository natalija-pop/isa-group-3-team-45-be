using ISAProject.Modules.Company.API.Dtos;
using ISAProject.Modules.Company.API.Public;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Company
{
    [Route("api/appointment")]
    public class AppointmentController : BaseApiController
    { 
        private readonly IAppointmentService _appointmentService;
        private readonly IEquipmentService _equipmentService;

        public AppointmentController(IAppointmentService service, IEquipmentService equipmentService)
        {
            _appointmentService = service;
            _equipmentService = equipmentService;
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

        [HttpPost("checkvalidity")]
        public ActionResult CheckAppointmentValidity([FromBody] AppointmentValidationDto appointmentValidation)
        {
            bool isAppointmentValid = _appointmentService.IsAppointmentValid(
               appointmentValidation.Date,
               appointmentValidation.CompanyId,
               appointmentValidation.AdminName,
               appointmentValidation.AdminSurname
            );

            return Ok(isAppointmentValid);
        }

        [HttpGet("getCompanyAppointments/{companyId:int}")]
        public ActionResult<AppointmentDto> GetCompanyAppointments([FromRoute] int companyId)
        {
            return CreateResponse(_appointmentService.GetCompanyAppointments(companyId));
        }

        [HttpPut("reserveAppointment/{appointmentId:int}")]
        public ActionResult<AppointmentDto>ReserveAppointment([FromBody] AppointmentDto appointmentDto)
        {
            foreach (var eq in appointmentDto.Equipment)
            {
                eq.ReservedQuantity += 1;
            }
            return CreateResponse(_appointmentService.Update(appointmentDto));
        }

        [HttpGet("checkIfEquipmentIsReserved/{equipmentId:int}")]
        public ActionResult IsEquipmentReserved([FromRoute] int equipmentId)
        {
            bool isEquipmentReserved = _appointmentService.IsEquipmentReserved(equipmentId);

            return Ok(isEquipmentReserved);
        }
    }
}
