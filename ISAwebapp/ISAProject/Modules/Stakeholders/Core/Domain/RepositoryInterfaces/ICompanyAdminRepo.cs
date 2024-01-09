namespace ISAProject.Modules.Stakeholders.Core.Domain.RepositoryInterfaces
{
    public interface ICompanyAdminRepo
    {
        CompanyAdmin Create(CompanyAdmin companyAdmin);
        List<CompanyAdmin> GetCompanyAdmins(long companyId);
        
    }
}
