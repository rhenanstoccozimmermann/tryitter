using System.IdentityModel.Tokens.Jwt;  // importação para o JwtSecurityTokenHandler
using Microsoft.IdentityModel.Tokens;   // importação para o SigningCredentials e Descriptor
using System.Text;                      // importação para o Encoding
using tryitter.Constants;
// using System.Security.Claims;
// using tryitter.Models

namespace tryitter.Services 
{
    public class TokenGenerator
    {
        public string Generate()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.ASCII.GetBytes(TokenConstants.Secret)), SecurityAlgorithms.HmacSha256Signature ),
                Expires = DateTime.Now.AddDays(15)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}