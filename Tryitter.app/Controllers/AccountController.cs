using Microsoft.AspNetCore.Authorization;
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
        /// <param name="account">the new account</param>
        [HttpPost("account")]
        public IActionResult AddAccount(Account account)
        {
            var result = _service.AddAccount(account);
            if (result is null)
            {
              return BadRequest("Dados inválidos");
            }
            return Ok(result);
        }

        /// <summary>This function returns an account</summary>
        /// <param name="accountId">the account id</param>
        /// <returns>the account</returns>
        [Authorize]
        [HttpGet("account/{accountId}")]
        public IActionResult GetAccountById(int accountId)
        {
            var result = _service.GetAccountById(accountId);
            if (result is null)
            {
                return NotFound("Conta não encontrada");
            }
            return Ok(result);
        }

        /// <summary>This function return a list of accounts</summary>
        /// <returns>a account list</returns>
        [Authorize]
        [HttpGet("account")]
        public IActionResult GetAllAccounts()
        {
            var result = _service.GetAllAccounts();
            if (result is null)
            {
                return NotFound("Nenhuma conta encontrada");
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
        [Authorize]
        [HttpPut("account/{accountId}")]
        public IActionResult UpdateAccount(int accountId, Account model)
        {
            var result = _service.UpdateAccount(accountId, model);
            if (result is null)
            {
                return NotFound("Conta não encontrada");
            }
            return Ok(result);
        }

        /// <summary>This function deletes an account</summary>
        /// <param name="accountId">the account id</param>
        [Authorize]
        [HttpDelete("account/{accountId}")]
        public IActionResult DeleteAccount(int accountId)
        {
            var result = _service.DeleteAccount(accountId);
            if (result is null)
            {
                return NotFound("Conta não encontrada");
            }
            return NoContent();
        }
    }
}
