using BussinessObject.Model;

namespace Repositories
{
    public interface IAccountRepository
    {
        Account GetAccountByEmail(string email);
        List<Account> GetAllAccounts();
        Account GetAccountById(int accountId);
        void CreateAccount(Account account);
        void UpdateAccount(Account account);
        void DeactivateAccount(Account account);
        List<Account> SearchAccounts(string searchTerm, string sortOption, string filterOption);
    }
}