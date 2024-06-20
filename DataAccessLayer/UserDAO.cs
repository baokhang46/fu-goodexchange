using BussinessObject.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public static class UserDAO
    {
        public static User GetUserById(int userId)
        {
            try
            {
                using var db = new FugoodexchangeContext();
                return db.Users.FirstOrDefault(u => u.UserId == userId);
            }
            catch (Exception e)
            {
                throw new Exception($"An error occurred while retrieving user with ID {userId}.", e);
            }
        }

        public static List<User> GetAllUsers()
        {
            try
            {
                using var db = new FugoodexchangeContext();
                return db.Users.ToList();
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred while retrieving all users.", e);
            }
        }

        public static void AddUser(User user)
        {
            try
            {
                using var context = new FugoodexchangeContext();
                context.Users.Add(user);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred while adding the user.", e);
            }
        }

        public static void UpdateUser(User user)
        {
            try
            {
                using var context = new FugoodexchangeContext();
                context.Entry(user).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred while updating the user.", e);
            }
        }

        public static void DeleteUser(int userId)
        {
            try
            {
                using var context = new FugoodexchangeContext();
                var user = context.Users.SingleOrDefault(u => u.UserId == userId);
                if (user != null)
                {
                    context.Users.Remove(user);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred while deleting the user.", e);
            }
        }
    }
}
