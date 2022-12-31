using APP_API.Data;
using APP_API.Models;
using APP_API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APP_API.Controllers
{
    [ApiController]
    [Route("v1/login")]
    public class LoginController : ControllerBase
    {
        public LoginController()
        {
        }

        [HttpPost]
        // [Route("logar")]
        public async Task<ActionResult<dynamic>> AutenticarUsuario
        ([FromServices] AppDbContext context,
        [FromServices] ITokenService tokenService,
        [FromBody] Usuario usuario)
        {
            var user = await context.Usuarios.AsNoTracking().FirstOrDefaultAsync(x => x.Email.ToLower() == usuario.Email.ToLower()&& x.Senha.ToLower() == usuario.Senha.ToLower());

            if(user is null)
                return NotFound(new {message = "Usuario ou senha inválidos"});

            var token = tokenService.GerarToken(usuario);

            return new
            {
                user,
                token
            };
        }

    }
}