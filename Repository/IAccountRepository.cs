using tryitter.Models;

namespace tryitter.Repository
{
    public interface IAccountRepository
    {
      Account? AddAccount(Account model);
      Account GetAccountById(int id);
      Account GetAccountByUserData(Account model);
      IEnumerable<Account> GetAllAccounts();
      Account UpdateAccount(int id, Account model);
      void DeleteAccount(int id);   
    }
}
