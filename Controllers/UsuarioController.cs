using Microsoft.AspNetCore.Mvc;
using APP_API.Models;
using APP_API.Data;
using Microsoft.EntityFrameworkCore;
using APP_API.Settings;
using APP_API.Interfaces;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Authorization;
using APP_API.Data.Dtos.UsuarioDto;
using AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace APP_API.Controllers
{
    [ApiController]
    [Route("usuario")]
    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        [Route("{skip}/{take}")]
        public async Task<ActionResult> RetornarUsuarios
            (
            [FromServices] AppDbContext context,
            [FromServices] IMapper mapper,
            [FromRoute] int skip = 0,
            [FromRoute] int take = 100
            )
        {
            var total = await context.Usuarios.CountAsync();
            var usuarios = await
                context
                .Usuarios
                .Skip(skip)
                .Take(take)
                .ToListAsync();

            List<ReadUsuarioDto> usuarioDtos = mapper.Map<List<ReadUsuarioDto>>(usuarios);

            return Ok(
                new
                {
                    total,
                    skip,
                    take,
                    data = usuarioDtos
                }
                );
        }

        [HttpGet]
        [Route("{usuarioemail}")]
        public async Task<IActionResult> RetornaUsuario
        (
            [FromServices] AppDbContext context,
            [FromServices] IMapper mapper,
            [FromRoute] [EmailAddress] string usuarioemail
        )
        {
            var usuario = await context
            .Usuarios
            .FirstOrDefaultAsync(x => x.Email.ToLower() == usuarioemail.ToLower());

            if (usuario is null)
            {
                return NotFound("Usuario não encontrado");
            }

            ReadUsuarioDto usuarioDto = mapper.Map<ReadUsuarioDto>(usuario);

            return Ok(usuarioDto);
        }

        [HttpPut]
        [Route("atualizar/{email}")]
        public async Task<IActionResult> AtualizarUsuario
            (
                [FromServices] AppDbContext context,
                [FromServices] IMapper mapper,
                [FromRoute] [EmailAddress] string email,
                [FromBody] CreateUsuarioDto usuarioDto
            )
        {
            if (email is null)
            {
                return BadRequest("O email está nulo");
            }

            if (usuarioDto is null)
            {
                return BadRequest("Os dados estão nulos");
            }
            
            Usuario usuario = mapper.Map<Usuario>(usuarioDto);

            context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (email != usuario.Email)
                {
                    return BadRequest("Usuário não existe");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();

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
                return NotFound(new { message = "Email ou senha inválidos" });

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