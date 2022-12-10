using tryitter.Models;

namespace tryitter.Service {
  public interface IAccountService {

    bool Login(Account user);
    string GenerateToken(Account user);
    // ClaimsIdentity AddClaims(Account user);
    bool AddAccount(Account user);
    Account GetAccountById(int accountId);
    IEnumerable<Account> GetAllAccounts();
    Account UpdateAccount(int accountId, Account user);
    bool DeleteAccount(int accountId);
  }
}
