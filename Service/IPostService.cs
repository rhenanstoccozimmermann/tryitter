using tryitter.Models;

namespace tryitter.Service {
  public interface IPostService {
      Post AddPost(Account account, string postContent);
      IEnumerable<Post> GetPostsByAccountId(int accountId);
      Post GetPostById(int postId);
      void UpdatePost(int postId, string postContent);
      void DeletePost(int postId);
  }
}
