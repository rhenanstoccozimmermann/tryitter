using tryitter.Models;

namespace tryitter.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IPostContext _context;
        public AccountRepository(IPostContext context)
        {
            _context = context;
        }

    public Account? Add(Account model)
    {
        try {
            _context.Accounts.Add(model);
            _context.SaveChanges();
            return model;
        } catch(Exception e) {
            System.Diagnostics.Debug.WriteLine(e.Message);
            return null;
        }
        
    }

    public void Delete(int id)
    {
      try {
            var account = _context.Accounts.First(a=>a.AccountId == id);
            _context.Accounts.Remove(account);
            _context.SaveChanges();
        } catch(Exception e) {
            System.Diagnostics.Debug.WriteLine(e.Message);
        }
    }

    public IEnumerable<Account> GetAll()
    {
        var list = new List<Account>();
        try {
            list = _context.Accounts.ToList();
        } catch(Exception e) {
            System.Diagnostics.Debug.WriteLine(e.Message);
        }
        return list;
    }

    public Account GetById(int id)
    {
        var account = new Account();
        try {
                account = _context.Accounts.First(a=>a.AccountId == id);
            } catch(Exception e) {
                    System.Diagnostics.Debug.WriteLine(e.Message);
            } 
        return account;  
    }

    public Account Update(int id, Account model)
    {
        var account = new Account();
        try {
                account = _context.Accounts.First(a=>a.AccountId == id);
                account.Email = model.Email;
                account.Name = model.Name;
                account.Module = model.Module;
                _context.Accounts.Update(account);
                _context.SaveChanges();
            } catch(Exception e) {
                    System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return account; 
    }
  }
}