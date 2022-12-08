using Microsoft.AspNetCore.Mvc;
using tryitter.Repository;

namespace tryitter.Controllers
{
    [ApiController]
    [Route("api")]
    public class PostController : Controller
    {
        private readonly IPostRepository _repository;
        public PostController(IPostRepository repository)
        {
            _repository = repository;
        }

        /// <summary> This function add a post</summary>
        /// <param name="accountId"> a account id</param>
        /// <param name="postContent"> a post content</param>
        /// <returns> a post id</returns>
        [HttpPost("post")]
        public IActionResult AddPost(int accountId, string postContent)
        {
            var account = _repository.GetAccountById(accountId);
            if (account == null)
            {
                return NotFound();
            }
            _repository.AddPost(account, postContent);
            return Ok(postContent);
        }

        /// <summary> This function return a list of posts</summary>
        /// <param name="accountId"> a account id</param>
        /// <returns> a posts list</returns>
        [HttpGet("post/account/{id}")]
        public IActionResult GetPostsByAccountId(int accountId)
        {
            var account = _repository.GetAccountById(accountId);
            if (account == null)
            {
                return NotFound();
            }
            return Ok(_repository.GetPostsByAccountId(accountId));
        }

        /// <summary> This function return a post</summary>
        /// <param name="postId"> a post id</param>
        /// <returns> a post</returns>
        [HttpGet("post/{id}")]
        public IActionResult GetPost(int postId)
        {
            var post = _repository.GetPostById(postId);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        /// <summary> This function update a post</summary>
        /// <param name="postId"> a post id</param>
        /// <returns> a post</returns>
        [HttpPut("post/{id}")]
        public IActionResult UpdatePost(int postId)
        {
            var post = _repository.GetPostById(postId);
            if (post == null)
            {
                return NotFound();
            }
            _repository.UpdatePost(postId);
            return Ok(postId);
        }

        /// <summary> This function delete a post</summary>
        /// <param name="postId"> a post id</param>
        /// <returns> a post</returns>
        [HttpDelete("post/{id}")]
        public IActionResult DeletePost(int postId)
        {
            var post = _repository.GetPostById(postId);
            if (post == null)
            {
                return NotFound();
            }
            _repository.DeletePost(postId);
            return Ok(postId); // poderia retornar tbm, talvez, "NoContent"
        }
    }
}
