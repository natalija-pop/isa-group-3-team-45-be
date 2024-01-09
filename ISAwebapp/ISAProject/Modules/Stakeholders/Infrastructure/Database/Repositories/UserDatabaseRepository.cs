using ISAProject.Modules.Database;
using ISAProject.Modules.Stakeholders.Core.Domain;
using ISAProject.Modules.Stakeholders.Core.Domain.RepositoryInterfaces;

namespace ISAProject.Modules.Stakeholders.Infrastructure.Database.Repositories
{
    public class UserDatabaseRepository : IUserRepository
    {
        private readonly DatabaseContext _dbContext;

        public UserDatabaseRepository(DatabaseContext dbContext)
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
    }
}
