using ISAProject.Modules.Database;
using ISAProject.Modules.Stakeholders.Core.Domain;
using ISAProject.Modules.Stakeholders.Core.Domain.RepositoryInterfaces;

namespace ISAProject.Modules.Stakeholders.Infrastructure.Database.Repositories
{
    public class CompanyAdminRepository: ICompanyAdminRepo
    {
        private readonly DatabaseContext _dbContext;
        public CompanyAdminRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public CompanyAdmin Create(CompanyAdmin companyAdmin)
        {
            _dbContext.CompanyAdmins.Add(companyAdmin);
            _dbContext.SaveChanges();
            return companyAdmin;
        }

        public List<CompanyAdmin> GetCompanyAdmins(long companyId)
        {
            var companyAdmins = _dbContext.CompanyAdmins.ToList();
            return companyAdmins.FindAll(x => x.CompanyId == companyId);
        }

        public CompanyAdmin GetCompanyAdmin(long companyAdminId)
        {
            var companyAdmin = _dbContext.CompanyAdmins.FirstOrDefault(x => x.Id == companyAdminId);
            return companyAdmin;
        }
    }
}
