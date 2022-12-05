using tryitter.Models;
using Microsoft.EntityFrameworkCore;

namespace tryitter.Repository
{
    public class PostRepository : IPostRepository 
    {
        private readonly IPostContext _context;
        public PostRepository(IPostContext context)
        {
            _context = context;
        }

        public void AddPost(Account account, string postContent)
        {

            // Account foundAccount = GetAccountById(account.accountId);

            // if (foundAccount is null)
            //     throw new InvalidOperationException();

            // post.accountId = account.accountId;
            // post.content = postContent;
            // _context.SaveChanges();
        }
        public IEnumerable<Post> GetPostsByAccountId(int accountId)
        {
            return _context.Posts.Where(post => post.AccountId == accountId);
        }
        public Account GetAccountById(int accountId)
        {
            return _context.Accounts.Find(accountId)!;
        }
        // public Video GetPostById(int postId)
        // {
        //     return _context.Posts.Find(postId)!;
        // }
         public Post GetPostById(int PostId) {
            throw new NotImplementedException();
        }
        public void UpdatePost(int postId)
        {
            // if (GetPostById(postId).Any())
            //     throw new InvalidOperationException();

            // _context.Posts.Remove(channel);
            // _context.SaveChanges();
        }
        public void DeletePost(int postId)
        {
            if (GetPostById(postId) is null)
                throw new InvalidOperationException();

            _context.Posts.Remove(GetPostById(postId));
            _context.SaveChanges();
        }
    }
}
