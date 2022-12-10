using Microsoft.AspNetCore.Mvc;
using tryitter;
using tryitter.Models;
using tryitter.Service;

namespace tryitter.Controllers
{
    [ApiController]
    [Route("api")]
    public class PostController : ControllerBase
    {
        private readonly IPostService _service;

        public PostController(IPostService service)
        {
            _service = service;
        }

        /// <summary>This function adds a post</summary>
        /// <param name="accountId">the account id</param>
        /// <param name="postContent">the post content</param>
        [HttpPost("post")]
        public IActionResult AddPost(int accountId, string postContent)
        {
            var result = _service.AddPost(accountId, postContent);
            if (result == false)
            {
                return NotFound();
            }
            return Ok("O seu post foi incluído com sucesso");
        }

        /// <summary>This function returns a list of posts</summary>
        /// <param name="accountId">the account id</param>
        /// <returns>a posts list</returns>
        [HttpGet("post/account/{id}")]
        public IActionResult GetPostsByAccountId(int accountId)
        {
            var result = _service.GetPostsByAccountId(accountId);
            if (result is not IEnumerable<tryitter.Models.Post>)
            {
                return NotFound();
            }
            return Ok(result);
        }

        /// <summary>This function returns a post</summary>
        /// <param name="postId">the post id</param>
        /// <returns>a post</returns>
        [HttpGet("post/{id}")]
        public IActionResult GetPostById(int postId)
        {
            Post? result = _service.GetPostById(postId);
            if (result is not Post)
            {
                return NotFound();
            }
            return Ok(result);
        }

        /// <summary>This function updates a post</summary>
        /// <param name="postId">the post id</param>
        [HttpPut("post/{id}")]
        public IActionResult UpdatePost(int postId, string postContent)
        {
            var result = _service.UpdatePost(postId, postContent);
            if (result == false)
            {
                return NotFound();
            }
            return Ok("O seu post foi alterado com sucesso");
        }

        /// <summary>This function deletes a post</summary>
        /// <param name="postId">the post id</param>
        [HttpDelete("post/{id}")]
        public IActionResult DeletePost(int postId)
        {
            var result = _service.DeletePost(postId);
            if (result == false)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
