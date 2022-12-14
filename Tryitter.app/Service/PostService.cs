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

    public Post? AddPost(Post post)
    {
      var result = _accountRepository.GetAccountById(post.AccountId);
      if (result is null)
      {
        return null;
      }
      return _postRepository.AddPost(post);
    }

    public IEnumerable<Post>? GetPostsByAccountId(int accountId)
    {
      var result = _accountRepository.GetAccountById(accountId);
      if (result is null)
      {
        return null;
      }
      return _postRepository.GetPostsByAccountId(accountId);
    }

    public Post? GetPostById(int postId)
    {
      return _postRepository.GetPostById(postId);
    }

    public Post? UpdatePost(int postId, Post post)
    {
      var result = _postRepository.GetPostById(postId);
      if (result is not null && !string.IsNullOrWhiteSpace(post.Content))
      {
        result.Content = post.Content;
        return _postRepository.UpdatePost(result);
      }

      throw new InvalidOperationException("O texto não pode ser vazio");
    }

    public Post? DeletePost(int postId)
    {
      var result = _postRepository.GetPostById(postId);
      if (result is null)
      {
          return null;
      }
      return _postRepository.DeletePost(result);
    }
  }
}
