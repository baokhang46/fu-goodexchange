using BussinessObject.Model;
using Microsoft.EntityFrameworkCore;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        public AccountService()
        {
            _accountRepository = new AccountRepository();
        }

        public void CreateAccount(Account account)
        {
            _accountRepository.CreateAccount(account);
        }

       

        public Account GetAccountByEmail(string email)
        {
            return _accountRepository.GetAccountByEmail(email);
        }

        public Account GetAccountById(int accountId)
        {
            return _accountRepository.GetAccountById(accountId);
        }

        public void UpdateAccount(Account account)
        {
            _accountRepository.UpdateAccount(account);
        }


        public List<Account> GetAllAccounts()
        {
            return _accountRepository.GetAllAccounts();
        }

        public List<Account> SearchAccounts(string searchTerm, string sortOption, string filterOption)
        {
            return _accountRepository.SearchAccounts(searchTerm, sortOption, filterOption); 
        }
    }
}