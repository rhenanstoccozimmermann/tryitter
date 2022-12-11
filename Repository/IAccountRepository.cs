using tryitter.Models;

namespace tryitter.Repository
{
    public interface IAccountRepository
    {
      Account? AddAccount(Account account);
      Account? GetAccountById(int accountId);
      IEnumerable<Account>? GetAllAccounts();
      Account? UpdateAccount(Account account, string password, string module, int status);
      Account? DeleteAccount(Account account);   
    }
}
