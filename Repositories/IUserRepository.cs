using BussinessObject.Model;

namespace Repositories
{
    public interface IUserRepository
    {
        User GetUserById(int id);
        IEnumerable<User> GetAllUser();
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
    }
}
