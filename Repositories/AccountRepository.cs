using BussinessObject.Model;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class AccountRepository : IAccountRepository
    {
        public Account GetAccountByEmail(string email)
            => AccountDAO.GetAccountByEmail(email);
        public List<Account> GetAllAccounts()
            => AccountDAO.GetAllAccounts();
        public Account GetAccountById(int accountId)
            => AccountDAO.GetAccountById(accountId);
        public void CreateAccount(Account account)
            => AccountDAO.CreateAccount(account);
        public void UpdateAccount(Account account)
            => AccountDAO.UpdateAccount(account);
        public void DeactivateAccount(int accountId)
            => AccountDAO.DeactivateSystemAccount(accountId);
        public void ReactivateAccount(int accountId)
            => AccountDAO.DeactivateSystemAccount(accountId);

    }
}