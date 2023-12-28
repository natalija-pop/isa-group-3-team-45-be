using ISAProject.Modules.Database;
using ISAProject.Modules.Stakeholders.Core.Domain;
using ISAProject.Modules.Stakeholders.Core.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace ISAProject.Modules.Stakeholders.Infrastructure.Database.Repositories
{
    public class EmployeeRepository: IEmployeeRepository
    {
        private readonly DatabaseContext _dbContext;
        public EmployeeRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }


        public Employee Create(Employee employee)
        {
            _dbContext.Employees.Add(employee);
            _dbContext.SaveChanges();
            return employee;
        }

        public Employee Get(long employeeId)
        {
            var employee = _dbContext.Employees.Find(employeeId);
            if (employee == null) throw new KeyNotFoundException("Not found: " + employeeId);
            return employee;
        }
    }
}
