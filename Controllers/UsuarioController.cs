using Microsoft.AspNetCore.Mvc;
using APP_API.Models;
using APP_API.Data;
using Microsoft.EntityFrameworkCore;
using APP_API.Interfaces;
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
        [Route("buscar")] // buscar?skip=0&take=50
        public async Task<ActionResult> RetornarUsuarios
            (
            [FromServices] AppDbContext context,
            [FromServices] IMapper mapper,
            [FromQuery] int skip = 0,
            [FromQuery] int take = 100
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
        [Route("buscar/parametro")]
        public async Task<IActionResult> RetornaUsuario
        (
            [FromServices] AppDbContext context,
            [FromServices] IMapper mapper,
            [FromQuery] string email,
            [FromQuery] int id
        )
        {
            var usuario = await context
            .Usuarios
            .FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower() || u.Id == id);

            if (usuario is null)
            {
                return NotFound("Usuario n�o encontrado");
            }

            ReadUsuarioDto usuarioDto = mapper.Map<ReadUsuarioDto>(usuario);

            return Ok(usuarioDto);
        }

        [HttpPut]
        [Route("atualizar/{id}")]
        public async Task<IActionResult> AtualizarUsuario
            (
                [FromServices] AppDbContext context,
                [FromServices] IMapper mapper,
                [FromRoute] int id,
                [FromBody] PutUsuarioDto usuarioDto
            )
        {
            Usuario usuario = mapper.Map<Usuario>(usuarioDto);

            if (usuario == null)
            {
                return BadRequest();
            }

            var existeUsuario = await context.Usuarios.FindAsync(id);

            if (existeUsuario is null)
            {
                return NotFound("O usuario n�o existe");
            }


            existeUsuario.Nome = usuario.Nome != null ? usuario.Nome : existeUsuario.Nome;
            existeUsuario.Telefone = usuario.Telefone != null ? usuario.Telefone : existeUsuario.Telefone;
            existeUsuario.Cpf = usuario.Cpf != null ? usuario.Cpf : existeUsuario.Cpf;
            existeUsuario.Email = usuario.Email != null ? usuario.Email : existeUsuario.Email;
            existeUsuario.Senha = usuario.Senha != null ? usuario.Senha : existeUsuario.Senha;

            context.Usuarios.Update(existeUsuario);
            await context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        [Route("deletar/{id}")]
        public async Task<IActionResult> DeletarUsuario
        (
            [FromServices] AppDbContext context,
            [FromRoute] int id
        )
        {
            var usuario = await context.Usuarios.FindAsync(id);
            if (usuario is null)
            {
                return NotFound();
            }

            context.Usuarios.Remove(usuario);
            await context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> AutenticarUsuario
       ([FromServices] AppDbContext context,
       [FromServices] ITokenService tokenService,
       [FromBody] LogarUsuarioDto usuarioDto) // Nesse m�todo, s� precisamos passar o email e a senha
        {
            var user = await context
                .Usuarios
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Email.ToLower() == usuarioDto.Email.ToLower() && x.Senha.ToLower() == usuarioDto.Senha.ToLower());

            if (user is null)
                return NotFound(new { message = "Email ou senha inv�lidos" });

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