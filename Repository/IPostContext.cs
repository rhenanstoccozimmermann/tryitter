using Microsoft.EntityFrameworkCore;
using tryitter.Models;

namespace tryitter.Repository
{
    public interface IPostContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public int SaveChanges();
    }
}
