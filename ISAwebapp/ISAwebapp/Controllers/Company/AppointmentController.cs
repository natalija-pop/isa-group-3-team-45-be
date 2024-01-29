﻿using ISAProject.Configuration.Core.UseCases;
using ISAProject.Modules.Company.API;
using ISAProject.Modules.Company.API.Dtos;
using ISAProject.Modules.Company.API.Public;
using ISAProject.Modules.Stakeholders.API.Public;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Company
{
    [Route("api/appointment")]
    public class AppointmentController : BaseApiController
    { 
        private readonly IAppointmentService _appointmentService;
        private readonly IEquipmentService _equipmentService;
        private readonly IEmailService _emailService;
        private readonly IUserService _userService;

        public AppointmentController(IAppointmentService service, IEquipmentService equipmentService, IEmailService emailService, IUserService userService)
        {
            _appointmentService = service;
            _equipmentService = equipmentService;
            _emailService = emailService;
            _userService = userService;
        }
        
        [HttpPost]
        public ActionResult<AppointmentDto> Create([FromBody] AppointmentDto appointmentDto)
        {
            var result = _appointmentService.Create(appointmentDto);
            return CreateResponse(result);
        }

        [HttpPost("additionalAppointment")]
        public ActionResult<AppointmentDto> CreateAdditionalAppointment([FromBody] AppointmentDto appointmentDto, [FromQuery] string userEmail)
        {
            _emailService.SendAppointmentConfirmation(appointmentDto, userEmail);
            var result = _appointmentService.CreateNewAppointment(appointmentDto);
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

        [HttpGet("getRecommendedAppointments/{companyId:int}")]
        public ActionResult<AppointmentDto> GetRecommendedAppointments([FromRoute] int companyId, [FromQuery] DateTime selectedDate)
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

        [HttpGet("getCustomerAppointments/{customerId:int}")]
        public ActionResult<AppointmentDto> GetCustomerAppointments([FromRoute] int customerId)
        {
            return CreateResponse(_appointmentService.GetCustomerAppointments(customerId));
        }

        [HttpGet("getCustomerProcessedAppointments/{customerId:int}")]
        public ActionResult<AppointmentDto> GetCustomerProcessedAppointments([FromRoute] int customerId)
        {
            return CreateResponse(_appointmentService.GetCustomerProcessedAppointments(customerId));
        }

        [HttpGet("getCustomerScheduledAppointments/{customerId:int}")]
        public ActionResult<AppointmentDto> GetCustomerScheduledAppointments([FromRoute] int customerId)
        {
            return CreateResponse(_appointmentService.GetCustomerScheduledAppointments(customerId));
        }

        [HttpPut("reserveAppointment")]
        public ActionResult<AppointmentDto> ReserveAppointment([FromBody] AppointmentDto appointmentDto, [FromQuery] string userEmail)
        {
            _emailService.SendAppointmentConfirmation(appointmentDto, userEmail);
            return CreateResponse(_appointmentService.ReserveAppointment(appointmentDto));
        }
        
        [HttpPut("cancelAppointment")]
        public ActionResult<AppointmentDto> CancelAppointment([FromBody] AppointmentDto appointmentDto, [FromQuery] long userId)
        {
            _equipmentService.UpdateCanceled(appointmentDto.Equipment);
            _userService.AddCancelationPenalty(userId, appointmentDto.Start);
            return CreateResponse(_appointmentService.CancelAppointment(appointmentDto));
        }

        [HttpPut("markAppointmentAsProcessed")]
        public ActionResult<AppointmentDto> MarkAppointmentAsProcessed([FromBody] AppointmentDto appointmentDto, [FromQuery] string userEmail)
        {
            _emailService.SendProcessedAppointmentConfirmation(appointmentDto, userEmail);
            _equipmentService.UpdateProcessed(appointmentDto.Equipment);
            return CreateResponse(_appointmentService.MarkAppointmentAsProcessed(appointmentDto));
        }

        [HttpGet("checkIfEquipmentIsReserved/{equipmentId:int}")]
        public ActionResult IsEquipmentReserved([FromRoute] int equipmentId)
        {
            bool isEquipmentReserved = _appointmentService.IsEquipmentReserved(equipmentId);

            return Ok(isEquipmentReserved);
        }

        [HttpGet("barcode/{userId:int}")]
        public IActionResult GetBarcodeImage([FromRoute] int userId)
        {
            List<string> base64ImageStrings = _appointmentService.RetrieveBarcodeImageData(userId.ToString());
            return Ok(base64ImageStrings);
        }
    }
}
