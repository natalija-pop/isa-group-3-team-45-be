namespace ISAProject.Modules.Stakeholders.Core.Domain.RepositoryInterfaces
{
    public interface ICompanyAdminRepo
    {
        User Create(User user, long companyId);
        List<User> GetCompanyAdmins(long companyId);
        
    }
}
