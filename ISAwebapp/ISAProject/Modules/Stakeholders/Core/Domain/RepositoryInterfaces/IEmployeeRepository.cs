namespace ISAProject.Modules.Stakeholders.Core.Domain.RepositoryInterfaces
{
    public interface IEmployeeRepository
    {
        Employee Create(Employee employee);
        Employee Get(long employeeId);
    }
}
