using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using APP_API.Models;
using APP_API.Settings;
using Microsoft.IdentityModel.Tokens;

namespace APP_API.Services
{
    public class TokenService
    {
        public string GerarToken(Usuario Usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Setting.ChaveSecreta);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject= new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, Usuario.NomeDeUsuario),
                    new Claim(ClaimTypes.Email, Usuario.Email),
                    new Claim(ClaimTypes.Role, Usuario.Role)
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