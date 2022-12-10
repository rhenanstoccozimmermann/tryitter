using tryitter.Models;

namespace tryitter.Repository
{
    public interface IAccountRepository
    {
      Account? Add(Account model);
      Account GetById(int id);
      void Delete(int id);
      Account Update(int id, Account model);
      IEnumerable<Account> GetAll();       
    }
}