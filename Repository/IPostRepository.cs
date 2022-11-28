using tryitter.Models;

namespace tryitter.Repository
{
    public interface IPostRepository
    {
        void AddPost(Account account, string postContent);
        IEnumerable<Post> GetPostsByAccountId(int accountId);
        Account GetAccountById(int accountId);
        Post GetPostById(int postId);
        void UpdatePost(int postId);
        void DeletePost(int postId);
    }
}
