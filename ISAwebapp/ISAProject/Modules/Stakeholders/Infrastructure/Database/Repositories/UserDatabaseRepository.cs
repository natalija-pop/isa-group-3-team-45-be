using ISAProject.Modules.Stakeholders.Core.Domain;
using ISAProject.Modules.Stakeholders.Core.Domain.RepositoryInterfaces;

namespace ISAProject.Modules.Stakeholders.Infrastructure.Database.Repositories
{
    public class UserDatabaseRepository : IUserRepository
    {
        private readonly StakeholdersContext _dbContext;

        public UserDatabaseRepository(StakeholdersContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User Create(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return user;
        }

        public bool Exists(string email)
        {
            return _dbContext.Users.Any(user => user.Email == email);
        }

        public User? GetActiveUserByEmail(string email)
        {
            return _dbContext.Users.FirstOrDefault(user => user.Email == email && user.IsActivated);
        }
        
        public CompanyAdmin Create(CompanyAdmin companyAdmin)
        {
            _dbContext.CompanyAdmins.Add(companyAdmin);
            _dbContext.SaveChanges();
            return companyAdmin;
        }
        //TODO: 2. DeleteCompanyAdmin
    }
}
