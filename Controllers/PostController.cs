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

        /// <summary> This function add a post</summary>
        /// <param name="accountId"> a account id</param>
        /// <param name="postContent"> a post content</param>
        /// <returns> a post id</returns>
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

        /// <summary> This function return a list of posts</summary>
        /// <param name="accountId"> a account id</param>
        /// <returns> a posts list</returns>
        [HttpGet("post/account/{id}")]
        public IActionResult GetPostsByAccountId(int accountId)
        {
            var result = _service.GetPostsByAccountId(accountId);
            if (result == false)
            {
                return NotFound();
            }
            return Ok(result);
        }

        /// <summary> This function return a post</summary>
        /// <param name="postId"> a post id</param>
        /// <returns> a post</returns>
        [HttpGet("post/{id}")]
        public IActionResult GetPostById(int postId)
        {
            var result = _service.GetPostById(postId);
            if (result == false)
            {
                return NotFound();
            }
            return Ok(result);
        }

        /// <summary> This function update a post</summary>
        /// <param name="postId"> a post id</param>
        /// <returns> a post</returns>
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

        /// <summary> This function delete a post</summary>
        /// <param name="postId"> a post id</param>
        /// <returns> a post</returns>
        [HttpDelete("post/{id}")]
        public IActionResult DeletePost(int postId)
        {
            var result = _service.DeletePost(postId);
            if (result == false)
            {
                return NotFound();
            }
            return NoContent("O seu post foi removido com sucesso");
        }
    }
}
