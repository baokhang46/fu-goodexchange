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
                context.Entry<Account>(account).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void DeactivateSystemAccount(int accountId)
        {
            try
            {
                using var context = new FugoodexchangeContext();
                var account = context.Accounts.SingleOrDefault(c => c.AccountId == accountId);
                if (account != null)
                {
                    account.Status = "Inactive";
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void ReactivateSystemAccount(int accountId)
        {
            try
            {
                using var context = new FugoodexchangeContext();
                var account = context.Accounts.SingleOrDefault(c => c.AccountId == accountId);
                if (account != null)
                {
                    account.Status = "Active";
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}