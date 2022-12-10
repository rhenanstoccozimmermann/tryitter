using tryitter.Models;

namespace tryitter.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IContext _context;
        public AccountRepository(IContext context)
        {
            _context = context;
        }

    public Account? AddAccount(Account model)
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

    public Account GetAccountById(int id)
    {
        var account = new Account();
        try {
                account = _context.Accounts.First(a=>a.AccountId == id);
            } catch(Exception e) {
                    System.Diagnostics.Debug.WriteLine(e.Message);
            } 
        return account;  
    }

    public Account GetAccountByUserData(Account model)
    {
        var account = new Account();
        try {
                account = _context.Accounts.First(a=>a.name == model.Name && a.email == model.Email);
            } catch(Exception e) {
                    System.Diagnostics.Debug.WriteLine(e.Message);
            } 
        return account;  
    }

    public IEnumerable<Account> GetAllAccounts()
    {
        var list = new List<Account>();
        try {
            list = _context.Accounts.ToList();
        } catch(Exception e) {
            System.Diagnostics.Debug.WriteLine(e.Message);
        }
        return list;
    }

    public Account UpdateAccount(int id, Account model)
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

    public void DeleteAccount(int id)
    {
      try {
            var account = _context.Accounts.First(a=>a.AccountId == id);
            _context.Accounts.Remove(account);
            _context.SaveChanges();
        } catch(Exception e) {
            System.Diagnostics.Debug.WriteLine(e.Message);
        }
    }
  }
}
