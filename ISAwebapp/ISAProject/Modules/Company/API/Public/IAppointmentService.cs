using FluentResults;
using ISAProject.Modules.Company.API.Dtos;
using ISAProject.Modules.Company.Core.Domain;

namespace ISAProject.Modules.Company.API.Public
{
    public interface IAppointmentService
    {
        Result<AppointmentDto> CreatePredefinedAppointment(AppointmentDto appointmentDto);
        Result<AppointmentDto> Get(int id);
        Result<AppointmentDto> Update(AppointmentDto appointmentDto);
        Result<AppointmentDto> ReserveAppointment(AppointmentDto appointmentDto);
        Result<AppointmentDto> MarkAppointmentAsProcessed(AppointmentDto appointmentDto);
        Result<List<AppointmentDto>> GetAll();
        Result<List<Appointment>> GenerateRecommendedAppointments(DateTime selectedDate, int companyId);
        Result<List<AppointmentDto>> GetCompanyAppointments(int companyId);
        Result<List<AppointmentDto>> GetCustomerAppointments(int customerId);

        public bool IsAppointmentValid(DateTime selectedDate, int companyId, string adminName, string adminSurname);
        public bool IsEquipmentReserved(int equipmentId);

        Result<AppointmentDto> ReserveScheduledAppointment(AppointmentDto appointmentDto);
        Result<AppointmentDto> ReadAppointmentQrCode(Stream stream);
        List<string> RetrieveBarcodeImageData(string userId);
        Result<List<AppointmentDto>> GetReservedByCompanyAdmin(int companyAdminId);
    }
}
