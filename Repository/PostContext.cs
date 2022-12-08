// using Microsoft.EntityFrameworkCore;
using tryitter.Models;

namespace tryitter.Repository;

public class PostContext : DbContext, IPostContext
{
    // public PostContext(DbContextOptions<PostContext> options) : base(options) { }
    // public PostContext() { }
    public DbSet<Post> Posts { get; set; } = default!;
    public DbSet<Account> Accounts { get; set; } = default!;
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.EnableSensitiveDataLogging();
    if (!optionsBuilder.IsConfigured)
    {
      optionsBuilder.UseSqlServer(
        @"Data Source=localhost; Initial Catalog=tryitterdb; User Id=sa; Password=Vpmr0BNHP1")
        .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }
  }
}
