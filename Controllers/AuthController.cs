using tryitter.ViewModels;

// função de autenticação do usuario.

[HttpPost]

public ActionResult<UserViewModel> Authenticate([FromBody] User user)
{
  UserViewModel userViewModel = new UserViewModel();
  try
  {
    userViewModel.User = new UserRepository().Get(user);

    if (userViewModel.User == null)
    {
      return NotFound("User not found!");
    }

    userViewModel.Token = new TokenGenerator().Generate();

    userViewModel.User.Password = string.Empty;
  } 
  catch (Exception ex)
  {
    return BadRequest(ex.Message);
  }
  return userViewModel;
}