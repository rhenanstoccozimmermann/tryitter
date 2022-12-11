using tryitter.Models;

namespace tryitter.Service {
  public interface IPostService {
      Post? AddPost(Post post);
      IEnumerable<Post>? GetPostsByAccountId(int accountId);
      Post? GetPostById(int postId);
      Post? UpdatePost(int postId, string postContent);
      Post? DeletePost(int postId);
  }
}
