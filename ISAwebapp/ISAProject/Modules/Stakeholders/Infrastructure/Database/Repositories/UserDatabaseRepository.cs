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

        public User GetById(long? appointmentCustomerId)
        {
            return _dbContext.Users.FirstOrDefault(user => user.Id == appointmentCustomerId && user.IsActivated);
        }

        public User Update(User user)
        {
            try
            {
                _dbContext.Update(user);
                _dbContext.SaveChanges();
            }
            catch (KeyNotFoundException ex)
            {
                throw new KeyNotFoundException("Exception! User not found!");
            }
            return user;
        }

        public List<User> GetUsersByIds(List<long> userIds)
        {
            return _dbContext.Users.Where(user => userIds.Contains(user.Id)).ToList();
        }

        public List<User> GetAll()
        {
            return _dbContext.Users.ToList();
        }
        public User FindUserById(long userId)
        {
            return _dbContext.Users.FirstOrDefault(user => user.Id == userId);
        }
        public bool HasDeletionPenaltyInCurrentMonth(long userId, DateTime todaysDate)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Id == userId);
            if (user == null)
            {
                return false;
            }

            return user.DeletionPenaltyDate.Month == todaysDate.Month;
        }

    }
}
