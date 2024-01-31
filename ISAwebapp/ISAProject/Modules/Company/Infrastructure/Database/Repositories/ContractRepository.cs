using ISAProject.Modules.Company.Core.Domain;
using ISAProject.Modules.Company.Core.Domain.RepositoryInterfaces;
using ISAProject.Modules.Database;
using ISAProject.Modules.Stakeholders.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISAProject.Modules.Company.Infrastructure.Database.Repositories
{
    public class ContractRepository : IContractRepository
    {
        private readonly ContractContext _dbContext;
        public ContractRepository(ContractContext dbContext)
        {
            _dbContext = dbContext;
        }
        public HospitalContract Create(HospitalContract contract)
        {
            contract.DeliveryTime = contract.DeliveryTime.ToUniversalTime();

            _dbContext.Contracts.Add(contract);
            _dbContext.SaveChanges();
            return contract;
        }

        public HospitalContract Update(HospitalContract contract)
        {
            try
            {
                _dbContext.Contracts.Update(contract);
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new KeyNotFoundException(e.Message);
            }
            return contract;
        }
    }
}
