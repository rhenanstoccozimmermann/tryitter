using tryitter.Models;

namespace tryitter.Service {
  public interface IAccountService {

    bool Login(Account user);
    string GenerateToken(Account user);
    Account GetAccountById(int accountId);
  }
}