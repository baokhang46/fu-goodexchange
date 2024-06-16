using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using BussinessObject.Model;

namespace DataAccessLayer
{
    public class UserDAO
    {
        private readonly    FugoodexchangeContext _context;
        private readonly ILogger<UserDAO> _logger;

        public UserDAO(FugoodexchangeContext context, ILogger<UserDAO> logger)
        {
            _context = context;
            _logger = logger;
        }

        // Create
        public async Task AddUserAsync(User user)
        {
            try
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding user");
                throw;
            }
        }

        // Read
        public async Task<User?> GetUserByIdAsync(int id)
        {
            try
            {
                return await _context.Users.FirstOrDefaultAsync(x => x.UserId == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching user by ID");
                throw;
            }
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            try
            {
                return await _context.Users.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching all users");
                throw;
            }
        }

        // Update
        public async Task UpdateUserAsync(User user)
        {
            try
            {
                var existingUser = await _context.Users.FirstOrDefaultAsync(x => x.UserId == user.UserId);
                if (existingUser != null)
                {
                    existingUser.FirstName = user.FirstName;
                    existingUser.LastName = user.LastName;
                    existingUser.Address = user.Address;
                    existingUser.Carts = user.Carts;
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating user");
                throw;
            }
        }

        // Delete
        public async Task DeleteUserAsync(int id)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.UserId == id);
                if (user != null)
                {
                    _context.Users.Remove(user);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting user");
                throw;
            }
        }
    }
}
