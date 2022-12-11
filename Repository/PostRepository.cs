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

        public Post? AddPost(int accountId, string postContent)
        {
            var post = new Post
            {
                AccountId = accountId,
                Content = postContent
            };
            _context.Posts.Add(post);
            _context.SaveChanges();
            return post;
        }

        public IEnumerable<Post>? GetPostsByAccountId(int accountId)
        {
            return _context.Posts.Where(post => post.AccountId == accountId);
        }

        public Post? GetPostById(int postId)
        {
            return _context.Posts.Find(postId);
        }

        public Post? UpdatePost(Post post, string postContent)
        {
            post.Content = postContent;
            _context.Posts.Update(post);
            _context.SaveChanges();
            return post;
        }

        public Post? DeletePost(Post post)
        {
            _context.Posts.Remove(post);
            _context.SaveChanges();
            return post;
        }
    }
}
