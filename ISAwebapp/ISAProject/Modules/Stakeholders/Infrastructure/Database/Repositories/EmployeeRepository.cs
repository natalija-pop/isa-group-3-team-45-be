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
    }
}
