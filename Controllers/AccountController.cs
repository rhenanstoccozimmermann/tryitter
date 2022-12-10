using Microsoft.AspNetCore.Mvc;
using tryitter;
using tryitter.Models;
using tryitter.Service;

namespace tryitter.Controllers
{
    [ApiController]
    [Route("api")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _service;

        public AccountController(IAccountService service)
        {
            _service = service;
        }

        /// <summary>This function adds an account</summary>
        /// <param name="name">the user name</param>
        /// <param name="email">the user email</param>
        /// <param name="password">the user password</param>
        /// <param name="module">the user actual module</param>
        /// <param name="status">the user actual status</param>
        [HttpPost("account")]
        public IActionResult AddAccount(Account account)
        {
            var result = _service.AddAccount(account);
            if (result == false)
            {
              return BadRequest("Já existe uma conta com este nome e email");
            }
            return Ok("A sua conta foi criada com sucesso");
        }

        /// <summary>This function returns an account</summary>
        /// <param name="accountId">the account id</param>
        /// <returns>the account</returns>
        [HttpGet("account/{id}")]
        public IActionResult GetAccountById(int accountId)
        {
            var result = _service.GetAccountById(accountId);
            if (result == false)
            {
                return NotFound();
            }
            return Ok(result);
        }

        /// <summary>This function return a list of accounts</summary>
        /// <returns>a account list</returns>
        [HttpGet("account")]
        public IActionResult GetAllAccounts()
        {
            var result = _service.GetAllAccounts();
            if (result == false)
            {
                return NotFound();
            }
            return Ok(result);
        }

        /// <summary>This function update an account</summary>
        /// <param name="accountId">the account id</param>
        /// <param name="name">the user name</param>
        /// <param name="email">the user email</param>
        /// <param name="password">the user password</param>
        /// <param name="module">the user actual module</param>
        /// <param name="status">the user actual status</param>
        [HttpPut("account/{id}")]
        public IActionResult UpdateAccount(int accountId, Account account)
        {
            var result = _service.UpdateAccount(accountId, account);
            if (result == false)
            {
                return NotFound();
            }
            return Ok(result);
        }

        /// <summary>This function deletes an account</summary>
        /// <param name="accountId">the account id</param>
        [HttpDelete("account/{id}")]
        public IActionResult DeleteAccount(int accountId)
        {
            var result = _service.DeleteAccount(accountId);
            if (result == false)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
