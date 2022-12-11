using tryitter.Models;
// using Microsoft.AspNetCore.Mvc;

namespace tryitter.Service {
  public interface IAccountService {

    bool Login(Account user);
    string GenerateToken(Account user);
    // ClaimsIdentity AddClaims(Account user);
    Account? AddAccount(Account account);
    Account? GetAccountById(int accountId);
    IEnumerable<Account>? GetAllAccounts();
    Account? UpdateAccount(int accountId, string password, string module, int status);
    Account? DeleteAccount(int accountId);
  }
}
