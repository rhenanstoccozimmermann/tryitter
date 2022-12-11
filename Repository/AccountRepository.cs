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

        public Account? AddAccount(Account account)
        {
            _context.Accounts.Add(account);
            _context.SaveChanges();
            return account;
            // try {
            //     _context.Accounts.Add(model);
            //     _context.SaveChanges();
            //     return model;
            // } catch(Exception e) {
            //     System.Diagnostics.Debug.WriteLine(e.Message);
            //     return null;
            // } 
        }

        public Account? GetAccountById(int accountId)
        {
            return _context.Accounts.First(a => a.AccountId == accountId);
            // var account = new Account();
            // try {
            //         account = _context.Accounts.First(a=>a.AccountId == id);
            //     } catch(Exception e) {
            //             System.Diagnostics.Debug.WriteLine(e.Message);
            //     } 
            // return account;
        }

        public IEnumerable<Account>? GetAllAccounts()
        {
            return _context.Accounts.ToList();
            // var list = new List<Account>();
            // try {
            //     list = _context.Accounts.ToList();
            // } catch(Exception e) {
            //     System.Diagnostics.Debug.WriteLine(e.Message);
            // }
            // return list;
        }

        public Account? UpdateAccount(Account account, string password, string module, int status)
        {
            account.Password = password;
            account.Module = module;
            account.Status = status;
            _context.Accounts.Update(account);
            _context.SaveChanges();
            return account;
            // var account = new Account();
            // try {
            //         account = _context.Accounts.First(a=>a.AccountId == id);
            //         account.Email = model.Email;
            //         account.Name = model.Name;
            //         account.Module = model.Module;
            //         _context.Accounts.Update(account);
            //         _context.SaveChanges();
            //     } catch(Exception e) {
            //             System.Diagnostics.Debug.WriteLine(e.Message);
            //     }
            //     return account; 
        }

        public Account? DeleteAccount(Account account)
        {
            _context.Accounts.Remove(account);
            _context.SaveChanges();
            return account;
        //   try {
        //         var account = _context.Accounts.First(a=>a.AccountId == id);
        //         _context.Accounts.Remove(account);
        //         _context.SaveChanges();
        //     } catch(Exception e) {
        //         System.Diagnostics.Debug.WriteLine(e.Message);
        //     }
        }
    }
}
