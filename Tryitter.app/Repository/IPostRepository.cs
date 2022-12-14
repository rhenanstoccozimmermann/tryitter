using tryitter.Models;

namespace tryitter.Repository
{
    public interface IPostRepository
    {
        Post? AddPost(Post post);
        IEnumerable<Post>? GetPostsByAccountId(int accountId);
        Post? GetPostById(int postId);
        Post? UpdatePost(Post post);
        Post? DeletePost(Post post);
    }
}
