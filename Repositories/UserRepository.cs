using BussinessObject.Model;
using DataAccessLayer;
using System.Collections.Generic;

namespace Repositories
{
    public class UserRepository : IUserRepository
    {
        public void AddUser(User user)
        {
            UserDAO.AddUser(user);
        }

        public IEnumerable<User> GetAllUser()
        {
            return UserDAO.GetAllUsers();
        }

        public User GetUserById(int id)
        {
            return UserDAO.GetUserById(id);
        }

        public void UpdateUser(User user)
        {
            UserDAO.UpdateUser(user);
        }

        public void DeleteUser(int id)
        {
            UserDAO.DeleteUser(id);
        }
    }
}
