using System;
using tryitter.Models;
using tryitter.Repository;

namespace tryitter.Service {
  public class PostService : IPostService {

    private readonly IPostRepository _postRepository;
    private readonly IAccountRepository _accountRepository;

    public PostService(IPostRepository postRepository, IAccountRepository accountRepository)
    {
      _postRepository = postRepository;
      _accountRepository = accountRepository;
    }

    public bool AddPost(int accountId, string postContent)
    {
      var account = _accountRepository.GetAccountById(accountId);
      if (account == null)
      {
        return false;
      }
      _postRepository.AddPost(account, postContent);
      return true;
    }

    public IEnumerable<Post>? GetPostsByAccountId(int accountId)
    {
      var account = _accountRepository.GetAccountById(accountId);
      if (account == null)
      {
        return null;
      }
      return _postRepository.GetPostsByAccountId(accountId);
    }

    public Post? GetPostById(int postId)
    {
      var post = _postRepository.GetPostById(postId);
      if (post == null)
      {
          return null;
      }
      return post;
    }

    public bool UpdatePost(int postId, string postContent)
    {
      var post = _postRepository.GetPostById(postId);
      if (post == null)
      {
          return false;
      }
      _postRepository.UpdatePost(post);
      return true;
    }

    public bool DeletePost(int postId)
    {
      var post = _postRepository.GetPostById(postId);
      if (post == null)
      {
          return false;
      }
      _postRepository.DeletePost(postId);
      return true;
    }
  }
}
