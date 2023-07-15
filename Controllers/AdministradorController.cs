using System.Data;
using APP_API.Data;
using APP_API.Data.Dtos.UsuarioDto;
using APP_API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APP_API.Controllers
{
    [ApiController]
    [Route("admin")] // o Admin tem acesso a todas as rotas e funcionalidades
    public class AdministradorController : ControllerBase
    {
        [HttpPost]
        [Route("criar")]
        public async Task<IActionResult> CriarAdmin
        ([FromServices] AppDbContext context,
         [FromServices] IMapper mapper,
         [FromBody]CreateUsuarioDto usuarioDto) // Usando o mapeando do AutoMapper
        {
            if (usuarioDto is null)
            {
                return BadRequest("O usuário está nulo!!!");
            }
            List<Usuario> administradores = await context
            .Usuarios
            .AsNoTracking()
            .Where(usuario => ((int)usuario.Role == 3))
            .ToListAsync();
            
            if (administradores.Count > 3)
            {
                return BadRequest("Nosso sistema impede de ter mais de 3 administradores");
            }

            Usuario user = mapper.Map<Usuario>(usuarioDto);


            user.Role = Role.Administrador;
            await context.Usuarios.AddAsync(user);
            await context.SaveChangesAsync();
            return Ok(user);
        }
    }
}