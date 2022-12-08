using Microsoft.AspNetCore.Mvc;
using tryitter;
using tryitter.Models;
using tryitter.Service;

namespace tryitter.Controllers {

    [Route("api/login")]
    [ApiController]
  public class AuthController : ControllerBase {

    private readonly IAccountService _service;

    public AuthController(IAccountService service)
    {
      _service = service;    
    }

[HttpPost]
public ActionResult<string> Authenticate([FromBody] Account user)
{
  bool isCorrectAccount = _service.Login(user);
  string token = string.Empty;
  if (isCorrectAccount) {
    token = _service.GenerateToken(user);
    return Ok(token);
  }
  return BadRequest("Dados inválidos");
  
}

}

}
// função de autenticação do usuario.
