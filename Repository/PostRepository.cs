using tryitter.Models;
using Microsoft.EntityFrameworkCore;

namespace tryitter.Repository
{
    public class PostRepository : IPostRepository 
    {
        private readonly IContext _context;
        public PostRepository(IContext context)
        {
            _context = context;
        }

        public void AddPost(Account account, string postContent)
        {
            var post = new Post();
            post.accountId = account.accountId;
            post.content = postContent;
            _context.Posts.Add(post);
            _context.SaveChanges();
        }

        public List<Post> GetPostsByAccountId(int accountId)
        {
            return _context.Posts.Where(post => post.AccountId == accountId);
        }

        public Post GetPostById(int postId)
        {
            return _context.Posts.Find(postId)!;
        }

        public void UpdatePost(Post post)
        {
            post.content = postContent;
            _context.Posts.Update(post);
            _context.SaveChanges();
        }

        public void DeletePost(int postId)
        {
            _context.Posts.Remove(GetPostById(postId));
            _context.SaveChanges();
        }
    }
}
