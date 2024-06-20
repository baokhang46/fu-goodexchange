using BussinessObject.Model;
using Microsoft.EntityFrameworkCore;
namespace DataAccessLayer
{
    public class AccountDAO
    {
        public static Account GetAccountByEmail(string email)
        {
            using var db = new FugoodexchangeContext();
            return db.Accounts.FirstOrDefault(x => x.Email.Equals(email));
        }

        public static List<Account> GetAllAccounts()
        {
            var listSystemAccounts = new List<Account>();
            try
            {
                using var db = new FugoodexchangeContext();
                listSystemAccounts = db.Accounts.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listSystemAccounts;
        }

        public static Account GetAccountById(int accountId)
        {
            using var db = new FugoodexchangeContext();
            return db.Accounts.FirstOrDefault(c => c.AccountId.Equals(accountId));
        }

        public static void CreateAccount(Account account)
        {
            try
            {
                using var context = new FugoodexchangeContext();
                context.Accounts.Add(account);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void UpdateAccount(Account account)
        {

            try
            {
                using var context = new FugoodexchangeContext();
                context.Entry<Account>(account).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update account", ex);
            }

        }
    



        public static void DeactivateAccount(Account account)
        {
            try
            {
                using var context = new FugoodexchangeContext();

               
                var accountToDeactivate = context.Accounts.Find(account.AccountId);
                if (accountToDeactivate != null)
                {
                    accountToDeactivate.Status = "Inactive"; 
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Account not found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while deactivating the account: {ex.Message}");
            }
        }

        public static List<Account> SearchAccounts(string searchTerm, string sortOption, string filterOption)
        {
            using var db = new FugoodexchangeContext();
            var accounts = db.Accounts.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                accounts = accounts.Where(a => a.Username.Contains(searchTerm));
            }

            if (filterOption == "active")
            {
                accounts = accounts.Where(a => a.Status == "Active");
            }
            else if (filterOption == "inactive")
            {
                accounts = accounts.Where(a => a.Status == "Inactive");
            }

            switch (sortOption)
            {
                case "name-asc":
                    accounts = accounts.OrderBy(a => a.Username);
                    break;
                case "name-desc":
                    accounts = accounts.OrderByDescending(a => a.Username);
                    break;               
            }

            return accounts.ToList();
        }

        public static void UpdatePassword(int accountId, string hashedPassword)
        {
            try
            {
                using var context = new FugoodexchangeContext();
                var accountToUpdate = context.Accounts.FirstOrDefault(a => a.AccountId == accountId);
                if (accountToUpdate != null)
                {
                    accountToUpdate.Password = hashedPassword;
                    context.Entry(accountToUpdate).State = EntityState.Modified;
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Account does not exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update password", ex);
            }
        }
    }
}