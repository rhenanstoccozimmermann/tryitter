// using Microsoft.EntityFrameworkCore;
using tryitter.Models;

namespace tryitter.Repository;

public class PostContext : DbContext, IPostContext
{
    public PostContext(DbContextOptions<PostContext> options) : base(options) { }
    public PostContext() { }
    public DbSet<Post> Posts { get; set; } = default!;
    public DbSet<Account> Accounts { get; set; } = default!;
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.EnableSensitiveDataLogging();
    if (!optionsBuilder.IsConfigured)
    {
      optionsBuilder.UseSqlServer(@"Server=localhost;Database=sqlserver;User=SA;Password=1q2w3e4r@#$")
        .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }
  }
}
