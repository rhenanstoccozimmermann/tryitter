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
        /// <param name="post">the new post</param>
        [HttpPost("post")]
        public IActionResult AddPost(Post post)
        {
            var result = _service.AddPost(post);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        /// <summary>This function returns a list of posts</summary>
        /// <param name="accountId">the account id</param>
        /// <returns>a posts list</returns>
        [HttpGet("post/account/{accountId}")]
        public IActionResult GetPostsByAccountId(int accountId)
        {
            var result = _service.GetPostsByAccountId(accountId);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        /// <summary>This function returns a post</summary>
        /// <param name="postId">the post id</param>
        /// <returns>a post</returns>
        [HttpGet("post/{postId}")]
        public IActionResult GetPostById(int postId)
        {
            var result = _service.GetPostById(postId);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        /// <summary>This function updates a post</summary>
        /// <param name="postId">the post id</param>
        [HttpPut("post/{postId}")]
        public IActionResult UpdatePost(int postId, string postContent)
        {
            var result = _service.UpdatePost(postId, postContent);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        /// <summary>This function deletes a post</summary>
        /// <param name="postId">the post id</param>
        [HttpDelete("post/{postId}")]
        public IActionResult DeletePost(int postId)
        {
            var result = _service.DeletePost(postId);
            if (result is null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
