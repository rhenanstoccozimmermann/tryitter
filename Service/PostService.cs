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

    public List<Post> GetPostsByAccountId(int accountId)
    {
      var account = _accountRepository.GetAccountById(accountId);
      if (account == null)
      {
        return false;
      }
      return _postRepository.GetPostsByAccountId(accountId);
    }

    public Post GetPostById(int postId)
    {
      var post = _postRepository.GetPostById(postId);
      if (post == null)
      {
          return false;
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

    public bool Delete(int id)
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
