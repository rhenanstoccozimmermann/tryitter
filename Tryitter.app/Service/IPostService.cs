using tryitter.Models;

namespace tryitter.Service {
  public interface IPostService {
      Post? AddPost(Post post);
      IEnumerable<Post>? GetPostsByAccountId(int accountId);
      Post? GetPostById(int postId);
      Post? UpdatePost(int postId, Post post);
      Post? DeletePost(int postId);
  }
}
