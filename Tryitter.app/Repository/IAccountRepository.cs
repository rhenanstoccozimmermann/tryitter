using tryitter.Models;

namespace tryitter.Repository
{
    public interface IAccountRepository
    {
      Account? AddAccount(Account account);
      Account? GetAccountById(int accountId);
      IEnumerable<Account>? GetAllAccounts();
      Account? UpdateAccount(Account account);
      Account? DeleteAccount(Account account);   
    }
}
