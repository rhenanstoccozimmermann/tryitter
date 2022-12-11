using tryitter.Models;

namespace tryitter.Repository
{
    public interface IPostRepository
    {
        Post? AddPost(int accountId, string postContent);
        IEnumerable<Post>? GetPostsByAccountId(int accountId);
        Post? GetPostById(int postId);
        Post? UpdatePost(Post post, string postContent);
        Post? DeletePost(Post post);
    }
}
