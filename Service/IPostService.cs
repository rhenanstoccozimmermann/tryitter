using tryitter.Models;

namespace tryitter.Service {
  public interface IPostService {
      bool AddPost(int accountId, string postContent);
      IEnumerable<Post> GetPostsByAccountId(int accountId);
      Post GetPostById(int postId);
      bool UpdatePost(int postId, string postContent);
      bool DeletePost(int postId);
  }
}
