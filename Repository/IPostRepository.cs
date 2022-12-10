using tryitter.Models;

namespace tryitter.Repository
{
    public interface IPostRepository
    {
        void AddPost(Account account, string postContent);
        IEnumerable<Post> GetPostsByAccountId(int accountId);
        Post GetPostById(int postId);
        void UpdatePost(Post post);
        void DeletePost(int postId);
    }
}
