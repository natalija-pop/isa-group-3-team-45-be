using ISAProject.Modules.Database;
using ISAProject.Modules.Stakeholders.Core.Domain;
using ISAProject.Modules.Stakeholders.Core.Domain.RepositoryInterfaces;

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

        public Employee Update(Employee employee)
        {
            try
            {
                _dbContext.Employees.Update(employee);
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new KeyNotFoundException(e.Message);
            }
            return employee;
        }
    }
}