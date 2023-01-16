using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using APP_API.Interfaces;
using APP_API.Models;
using APP_API.Settings;
using Microsoft.IdentityModel.Tokens;

namespace APP_API.Services
{
    public class TokenService : ITokenService
    {
        public string GerarToken(Usuario Usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Setting.ChaveSecreta);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, Usuario.Nome),
                    new Claim(ClaimTypes.Email, Usuario.Email),
                    new Claim(ClaimTypes.Role, Usuario.Role.ToString())
                }),

                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)


            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}