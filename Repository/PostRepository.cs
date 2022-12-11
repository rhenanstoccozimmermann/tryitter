using tryitter.Models;
// using Microsoft.EntityFrameworkCore;

namespace tryitter.Repository
{
    public class PostRepository : IPostRepository 
    {
        private readonly IContext _context;
        public PostRepository(IContext context)
        {
            _context = context;
        }

        public Post? AddPost(Post post)
        {
            try {
                _context.Posts.Add(post);
                _context.SaveChanges();
                return post;
            } catch(Exception e) {
                System.Diagnostics.Debug.WriteLine(e.Message);
                return null;
            } 
        }

        public IEnumerable<Post>? GetPostsByAccountId(int accountId)
        {
            try {
                return _context.Posts.Where(post => post.AccountId == accountId);
            } catch(Exception e) {
                System.Diagnostics.Debug.WriteLine(e.Message);
                return null;
            } 
        }

        public Post? GetPostById(int postId)
        {
            try {
                return _context.Posts.Find(postId);
            } catch(Exception e) {
                System.Diagnostics.Debug.WriteLine(e.Message);
                return null;
            } 
        }

        public Post? UpdatePost(Post post, string postContent)
        {
            try {
                post.Content = postContent;
                _context.Posts.Update(post);
                _context.SaveChanges();
                return post;
            } catch(Exception e) {
                System.Diagnostics.Debug.WriteLine(e.Message);
                return null;
            } 
        }

        public Post? DeletePost(Post post)
        {
            try {
                _context.Posts.Remove(post);
                _context.SaveChanges();
                return post;
            } catch(Exception e) {
                System.Diagnostics.Debug.WriteLine(e.Message);
                return null;
            } 
        }
    }
}
