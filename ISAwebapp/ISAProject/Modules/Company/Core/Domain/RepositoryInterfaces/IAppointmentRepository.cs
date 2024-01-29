using ISAProject.Modules.Database;

namespace ISAProject.Modules.Company.Core.Domain.RepositoryInterfaces
{
    public interface IAppointmentRepository
    {
        Appointment GetById(long id, DatabaseContext dbContext);
        Appointment Get(long id);
        List<Appointment> GetAll();
        Appointment Create(Appointment appointment);
        Appointment Update(Appointment appointment);
        Company GetAppointmentsCompany(long companyId);
        List<Appointment> GetCompanyAppointments(long companyId);
        List<Appointment> GetCustomerAppointments(long customerId);

        List<Equipment> GetWithIds(List<int> desiredEquipmentIds);
    }
}
