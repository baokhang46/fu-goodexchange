
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Repositories;
using BussinessObject.Model;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;

        public UserService(IUserRepository userRepo)
        {
            _userRepo = userRepo ?? throw new ArgumentNullException(nameof(userRepo));
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            try
            {
                return await _userRepo.GetAllUser();
            }
            catch (Exception ex)
            {
                // Log the exception
                throw new Exception($"Failed to retrieve user: {ex.Message}", ex);
            }
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            try
            {
                return await _userRepo.GetUserById(id);
            }
            catch (Exception ex)
            {
                // Log the exception
                throw new Exception($"Failed to retrieve user: {ex.Message}", ex);
            }
        }

        public async Task<int> CreateUserAsync(User user)
        {
            try
            {
                await _userRepo.AddUser(user);
                return user.UserId; 
            }
            catch (Exception ex)
            {
                // Log the exception
                throw new Exception($"Failed to create user: {ex.Message}", ex);
            }
        }

        public async Task<string> UpdateUserAsync(User user)
        {
            try
            {
                await _userRepo.UpdateUser(user);
                return "User updated successfully";
            }
            catch (Exception ex)
            {
                // Log the exception
                throw new Exception($"Failed to update user: {ex.Message}", ex);
            }
        }

        public async Task<string> DeleteUserAsync(int id)
        {
            try
            {
                await _userRepo.DeleteUser(id);
                return "User deleted successfully";
            }
            catch (Exception ex)
            {
                // Log the exception
                throw new Exception($"Failed to delete user: {ex.Message}", ex);
            }
        }
    }
}
