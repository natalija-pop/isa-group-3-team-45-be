using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISAProject.Modules.Company.Core.Domain.RepositoryInterfaces
{
    public interface IAppointmentRepository
    {
        Appointment Get(long id);
        List<Appointment> GetAll();
        Appointment Create(Appointment appointment);
        Appointment Update(Appointment appointment);
        Company GetAppointmentsCompany(long companyId);
        List<Appointment> GetCompanyAppointments(long companyId);
        List<Equipment> GetWithIds(List<int> desiredEquipmentIds);

    }
}
