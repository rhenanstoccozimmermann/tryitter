using System.IdentityModel.Tokens.Jwt;  // importação para o JwtSecurityTokenHandler
using Microsoft.IdentityModel.Tokens;   // importação para o SigningCredentials e Descriptor
using System.Text;                      // importação para o Encoding
using System.Security.Claims;
using tryitter.Constants;
using tryitter.Models;

namespace tryitter.Services 
{
    public class TokenGenerator
    {
        public string Generate(Account user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor();
            var key = Encoding.ASCII.GetBytes(TokenConstants.Secret);
            {
                Subject = AddClaims(user);
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature );
                Expires = DateTime.Now.AddDays(15);
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
    }
}