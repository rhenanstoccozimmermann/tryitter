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

    public Post? AddPost(int accountId, string postContent)
    {
      var account = _accountRepository.GetAccountById(accountId);
      if (account is null)
      {
        return null;
      }
      return _postRepository.AddPost(accountId, postContent);
    }

    public IEnumerable<Post>? GetPostsByAccountId(int accountId)
    {
      var account = _accountRepository.GetAccountById(accountId);
      if (account is null)
      {
        return null;
      }
      return _postRepository.GetPostsByAccountId(accountId);
    }

    public Post? GetPostById(int postId)
    {
      return _postRepository.GetPostById(postId);
    }

    public Post? UpdatePost(int postId, string postContent)
    {
      var post = _postRepository.GetPostById(postId);
      if (post is null)
      {
          return null;
      }
      return _postRepository.UpdatePost(post, postContent);
    }

    public Post? DeletePost(int postId)
    {
      var post = _postRepository.GetPostById(postId);
      if (post is null)
      {
          return null;
      }
      return _postRepository.DeletePost(post);
    }
  }
}
