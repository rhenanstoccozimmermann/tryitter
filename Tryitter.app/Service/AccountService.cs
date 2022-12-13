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

    public Account? AddAccount(Account account)
    {  
      Account? response = null;
      try 
      {
        if (validateAccount(account))
            response = _repository.AddAccount(account);
      } catch (Exception e) {
            System.Diagnostics.Debug.WriteLine(e.Message);
      }
      return response;
    }

    public Account? GetAccountById(int accountId)
    {
      return _repository.GetAccountById(accountId);
    }

    public IEnumerable<Account>? GetAllAccounts()
    {
      return _repository.GetAllAccounts();
    }

    public Account? UpdateAccount(int accountId, string password, string module, int status)
    {
      var result = _repository.GetAccountById(accountId);
      if (result is null)
      {
          return null;
      }
      return _repository.UpdateAccount(result, password, module, status);
    }

    public Account? DeleteAccount(int accountId)
    {
      var result = _repository.GetAccountById(accountId);
      if (result is null)
      {
          return null;
      }
      return _repository.DeleteAccount(result);
    }

    private bool validateAccount(Account model) {
      bool isValid = false;
      
      if (string.IsNullOrWhiteSpace(model.Name))
        throw new InvalidOperationException("Nome não pode ser nulo ou vazio");
      if (string.IsNullOrWhiteSpace(model.Email))
        throw new InvalidOperationException("Email não pode ser nulo ou vazio");
      if (string.IsNullOrWhiteSpace(model.Module))
        throw new InvalidOperationException("Módulo não pode ser nulo ou vazio");

      isValid = true;
      return isValid;
    }
  }
}
