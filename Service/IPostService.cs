using tryitter.Models;

namespace tryitter.Service {
  public interface IPostService {
      Post? AddPost(int accountId, string postContent);
      IEnumerable<Post>? GetPostsByAccountId(int accountId);
      Post? GetPostById(int postId);
      Post? UpdatePost(int postId, string postContent);
      Post? DeletePost(int postId);
  }
}
