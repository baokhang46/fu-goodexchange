using System;
using System.Collections.Generic;
using BussinessObject.Model;
using Repositories;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public IEnumerable<User> GetAllUsers()
        {
            try
            {
                return _userRepository.GetAllUser();
            }
            catch (Exception ex)
            {
                // Log the exception
                throw new Exception($"Failed to retrieve users: {ex.Message}", ex);
            }
        }

        public User GetUserById(int id)
        {
            try
            {
                return _userRepository.GetUserById(id);
            }
            catch (Exception ex)
            {
                // Log the exception
                throw new Exception($"Failed to retrieve user with id {id}: {ex.Message}", ex);
            }
        }

        public void CreateUser(User user)
        {
            try
            {
                _userRepository.AddUser(user);
            }
            catch (Exception ex)
            {
                // Log the exception
                throw new Exception($"Failed to create user: {ex.Message}", ex);
            }
        }

        public void UpdateUser(User user)
        {
            try
            {
                _userRepository.UpdateUser(user);
            }
            catch (Exception ex)
            {
                // Log the exception
                throw new Exception($"Failed to update user with id {user.UserId}: {ex.Message}", ex);
            }
        }

        public void DeleteUser(int id)
        {
            try
            {
                _userRepository.DeleteUser(id);
            }
            catch (Exception ex)
            {
                // Log the exception
                throw new Exception($"Failed to delete user with id {id}: {ex.Message}", ex);
            }
        }
    }
}
