using ISAProject.Modules.Company.Core.Domain;
using ISAProject.Modules.Company.Core.Domain.RepositoryInterfaces;
using ISAProject.Modules.Database;
using Microsoft.EntityFrameworkCore;
namespace ISAProject.Modules.Company.Infrastructure.Database.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly DatabaseContext _context;

        public AppointmentRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Appointment Create(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            _context.SaveChanges();
            return appointment;
        }

        public Appointment Get(long id)
        {
            var appointment = _context.Appointments.Find(id);
            if (appointment == null) throw new KeyNotFoundException("Appointment not found.");
            return appointment;
        }

        public List<Appointment> GetAll()
        {
            return _context.Appointments.ToList();
        }

        public List<Equipment> GetWithIds(List<int> desiredEquipmentIds)
        {
            return _context.Equipments.Where(e => desiredEquipmentIds.Contains((int)e.Id)).ToList();
        }

        public Appointment Update(Appointment appointment)
        {
            try
            {
                _context.Update(appointment);
                _context.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                throw new KeyNotFoundException(e.Message);
            }
            return appointment;
        }

        public Company.Core.Domain.Company GetAppointmentsCompany(long companyId)
        {
            var company = _context.Companies.Find(companyId);
            if (company == null) throw new KeyNotFoundException("Company not found.");
            return company;
        }

        public List<Appointment> GetCompanyAppointments(long companyId)
        {
            return GetAll().FindAll(x => x.CompanyId == companyId && x.Status == Appointment.AppointmentStatus.Predefined);
        }

        public List<Appointment> GetCustomerAppointments(long customerId)
        {
            return GetAll().FindAll(x => x.CustomerId == customerId );
        }

        public List<Appointment> GetCustomerScheduledAppointments(long customerId)
        {
            return GetAll().FindAll(x => x.CustomerId == customerId && x.Status == Appointment.AppointmentStatus.Scheduled);
        }

        public List<Appointment> GetCustomerProcessedAppointments(long customerId)
        {
            return GetAll().FindAll(x => x.CustomerId == customerId && x.Status == Appointment.AppointmentStatus.Processed);
        }
    }
}
