using ISAProject.Modules.Stakeholders.Core.Domain;
using ISAProject.Modules.Stakeholders.Core.Domain.RepositoryInterfaces;

namespace ISAProject.Modules.Stakeholders.Infrastructure.Database.Repositories
{
    public class CompanyAdminRepository: ICompanyAdminRepo
    {
        private readonly StakeholdersContext _dbContext;

        public CompanyAdminRepository(StakeholdersContext dbContext)
        {
            _dbContext = dbContext;
        }


        public User Create(User user, long companyId)
        {
            _dbContext.Users.Add(user);
            _dbContext.CompanyAdmins.Add(new CompanyAdmin(companyId, user));
            _dbContext.SaveChanges();
            return user;
        }

        public List<User> GetCompanyAdmins(long companyId)
        {
            var companyAdmins = _dbContext.CompanyAdmins.ToList();
            var users = _dbContext.Users.ToList();

            return users.FindAll(user =>
                companyAdmins.Any(x => x.UserId == user.Id && x.CompanyId == companyId));
        }
    }
}
