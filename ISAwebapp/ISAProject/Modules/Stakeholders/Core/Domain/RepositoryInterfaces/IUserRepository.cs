namespace ISAProject.Modules.Stakeholders.Core.Domain.RepositoryInterfaces
{
    public interface IUserRepository
    {
        bool Exists(string username);
        User? GetActiveUserByEmail(string email);
        User Create(User user);
        List<User> GetAll();
        List<User> GetUsersByIds(List<long> userIds);

    }
}
