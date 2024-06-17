using BussinessObject.Model;

namespace Services
{
    public interface IAccountService
    {
        Account GetAccountByEmail(string email);
        List<Account> GetAllAccounts();
        Account GetAccountById(int accountId);
        void CreateAccount(Account account);
        void UpdateAccount(Account account);
        public List<Account> SearchAccounts(string searchTerm, string sortOption, string filterOption);
    }
}