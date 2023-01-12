using Microsoft.AspNetCore.Mvc;
using APP_API.Models;
using APP_API.Data;
using Microsoft.EntityFrameworkCore;
using APP_API.Settings;
using APP_API.Interfaces;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Authorization;

namespace APP_API.Controllers
{
    [ApiController]
    [Route("usuario")]
    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        //[Route()]
        [Authorize(Roles = "Usuario.Role.3")]
        public async Task<ActionResult> RetornarUsuarios
            ([FromServices] AppDbContext context,
            [FromRoute] int skip = 0,
            [FromRoute] int take = 100)
        {
            var total = await context.Usuarios.CountAsync();
            var todos = await
                context
                .Usuarios
                .AsNoTracking()
                .Skip(skip)
                .Take(take)
                .ToListAsync();

            return Ok(
                new
                {
                    total,
                    skip,
                    take,
                    data = todos
                }
                );
        }

        [HttpGet]
        [Route("{usuarioemail}")]
        public async Task<IActionResult> RetornaUsuario
        ([FromServices] AppDbContext context,
            [FromRoute] string usuarioemail)
        {
            var usuario = await context.
            Usuarios.
            AsNoTracking()
            .FirstOrDefaultAsync(x => x.Email.ToLower() == usuarioemail.ToLower());
            return Ok(usuario);
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> AutenticarUsuario
       ([FromServices] AppDbContext context,
       [FromServices] ITokenService tokenService,
       [FromBody] Usuario usuario)
        {
            var user = await context.Usuarios.AsNoTracking().FirstOrDefaultAsync(x => x.Email.ToLower() == usuario.Email.ToLower() && x.Senha.ToLower() == usuario.Senha.ToLower());

            if (user is null)
                return NotFound(new { message = "Usuario ou senha inválidos" });

            var token = tokenService.GerarToken(usuario);

            return new
            {
                user,
                token
            };
        }
    }
}