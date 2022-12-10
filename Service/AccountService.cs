using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using tryitter.Constants;
using tryitter.Models;
using tryitter.Repository;

namespace tryitter.Service {
  public class AccountService : IAccountService {

    private readonly IAccountRepository _repository;

    public AccountService(IAccountRepository repository)
    {
      _repository = repository;
    }

    public bool Login(Account user) {
      bool isLogged = false;

      try {
        var model = _repository.GetById(user.AccountId);

        if (model is null)
          throw new ArgumentNullException("dados invalidos");
        
        isLogged = user.Email == model.Email && user.Password == user.Password;    
      } catch (Exception e) {
        System.Diagnostics.Debug.WriteLine(e.Message);
      }

      return isLogged;
    }

    public string GenerateToken (Account user) {
      
      var key = Encoding.ASCII.GetBytes(TokenConstants.Secret);
      var tokenHandler = new JwtSecurityTokenHandler();

      SecurityTokenDescriptor tokenDescriptor = new () 
        {
          Subject = AddClaims(user),
          SigningCredentials = new SigningCredentials
            (new SymmetricSecurityKey(Encoding.ASCII.GetBytes(TokenConstants.Secret)), SecurityAlgorithms.HmacSha256Signature),
          Expires = DateTime.Now.AddYears(1)
      };
    var token = tokenHandler.CreateToken(tokenDescriptor);

return tokenHandler.WriteToken(token);
    }

     private ClaimsIdentity AddClaims(Account user)
        {
            var claims = new ClaimsIdentity();

            claims.AddClaim(new Claim(ClaimTypes.Name, user.Name));
            return claims;
        }

    public Account? Add(Account model)
    {
      throw new NotImplementedException();
    }

    public Account GetAccountById(int accountId)
    {
      throw new NotImplementedException();
    }

    public void Delete(int id)
    {
      throw new NotImplementedException();
    }

    public Account Update(int id, Account model)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Account> GetAll()
    {
      throw new NotImplementedException();
    }
  }
}