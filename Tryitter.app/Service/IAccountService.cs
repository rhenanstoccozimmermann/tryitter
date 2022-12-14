using tryitter.Models;

namespace tryitter.Service {
  public interface IAccountService {
    bool Login(Account user);
    string GenerateToken(Account user);
    Account? AddAccount(Account model);
    Account? GetAccountById(int id);
    Account? DeleteAccount(int id);
    Account? UpdateAccount(int accountId, Account model);
    IEnumerable<Account>? GetAllAccounts(); 
  }
}