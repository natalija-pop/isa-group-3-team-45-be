using ISAProject.Modules.Stakeholders.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISAProject.Modules.Company.Core.Domain.RepositoryInterfaces
{
    public interface IContractRepository
    {
        HospitalContract Create(HospitalContract contract);
        HospitalContract Update(HospitalContract contract);
        List<HospitalContract> GetAll();
    }
}
