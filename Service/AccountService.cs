using System;
using Microsoft.AspNetCore.Mvc;
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
        var model = _repository.GetAccountById(user.AccountId);

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

    public bool AddAccount(Account model)
    {
      var account = _repository.GetAccountByUserData(model);
      if (account is null)
      {
        return false;
      }
      _repository.AddAccount(account);
      return true;
    }

    public Account GetAccountById(int accountId)
    {
      return _repository.GetAccountById(accountId);
    }

    public IEnumerable<Account> GetAllAccounts()
    {
      return _repository.GetAllAccounts();
    }

    public Account UpdateAccount(int accountId, Account model)
    {
      return _repository.UpdateAccount(accountId, model);
    }

    public bool DeleteAccount(int accountId)
    {
      var account = _repository.GetAccountById(accountId);
      if (account == null)
      {
          return false;
      }
      _repository.DeleteAccount(accountId);
      return true;
    }
  }
}
