using Microsoft.AspNetCore.Mvc;
using APP_API.Models;
using APP_API.Data;
using Microsoft.EntityFrameworkCore;
using APP_API.Settings;
using APP_API.Interfaces;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Authorization;
using APP_API.Data.Dtos.UsuarioDto;

namespace APP_API.Controllers
{
    [ApiController]
    [Route("usuario")]
    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        [Route("{skip}/{take}")]
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
       [FromBody] LogarUsuarioDto usuarioDto) // Nesse método, só precisamos passar o email e a senha
        {
            var user = await context
                .Usuarios
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Email.ToLower() == usuarioDto.Email.ToLower() && x.Senha.ToLower() == usuarioDto.Senha.ToLower());

            if (user is null)
                return NotFound(new { message = "Usuario ou senha inválidos" });

            var token = tokenService.GerarToken(user);

            return new
            {
                user.Nome,
                user.Role,
                token
            };
        }
    }
}