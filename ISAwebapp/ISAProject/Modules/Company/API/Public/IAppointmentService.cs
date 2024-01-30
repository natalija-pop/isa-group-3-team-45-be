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
        Result<AppointmentDto> CancelAppointment(AppointmentDto appointmentDto);
        Result<AppointmentDto> MarkAppointmentAsProcessed(AppointmentDto appointmentDto);
        Result<List<AppointmentDto>> GetAll();
        Result<List<Appointment>> GenerateRecommendedAppointments(DateTime selectedDate, int companyId);
        Result<List<AppointmentDto>> GetCompanyAppointments(int companyId);
        Result<List<AppointmentDto>> GetCustomerAppointments(int customerId);

        public bool IsAppointmentValid(DateTime selectedDate, int companyId, string adminName, string adminSurname);
        public bool IsEquipmentReserved(int equipmentId);
        public bool IsReservationEnabled(long appointmentId, int userId);

        Result<AppointmentDto> ReserveScheduledAppointment(AppointmentDto appointmentDto);
        Result<AppointmentDto> ReadAppointmentQrCode(Stream stream);
        Result<AppointmentDto> CreateNewAppointment(AppointmentDto appointmentDto);
        Result<List<AppointmentDto>> GetCustomerProcessedAppointments(int customerId);
        Result<List<AppointmentDto>> GetCustomerScheduledAppointments(int customerId);
        Result<List<AppointmentDto>> GetReservedByCompanyAdmin(int companyAdminId);
       
        List<string> RetrieveBarcodeImageData(string userId);
    }
}
