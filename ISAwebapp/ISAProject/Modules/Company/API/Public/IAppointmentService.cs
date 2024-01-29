using FluentResults;
using ISAProject.Configuration.Core.UseCases;
using ISAProject.Modules.Company.API.Dtos;
using ISAProject.Modules.Company.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISAProject.Modules.Company.API.Public
{
    public interface IAppointmentService
    {
        Result<AppointmentDto> Create(AppointmentDto appointmentDto);
        Result<AppointmentDto> Get(int id);
        Result<AppointmentDto> Update(AppointmentDto appointmentDto);
        Result<AppointmentDto> ReserveAppointment(AppointmentDto appointmentDto);
        Result<List<AppointmentDto>> GetAll();
        Result<List<Appointment>> GenerateRecommendedAppointments(DateTime selectedDate, int companyId);
        Result<List<AppointmentDto>> GetCompanyAppointments(int companyId);
        Result<List<AppointmentDto>> GetCustomerAppointments(int customerId);

        public bool IsAppointmentValid(DateTime selectedDate, int companyId, string adminName, string adminSurname);
        public bool IsEquipmentReserved(int equipmentId);

        Result<AppointmentDto> ReserveScheduledAppointment(AppointmentDto appointmentDto);

        List<string> RetrieveBarcodeImageData(string userId);
    }
}
