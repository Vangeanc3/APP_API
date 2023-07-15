using APP_API.Data;
using APP_API.Data.Dtos.UsuarioDto;
using APP_API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace APP_API.Controllers
{
    [ApiController]
    [Route("vendedor")]
    public class VendedorController : ControllerBase
    {
        [HttpPost]
        [Route("criar")]
        public async Task<IActionResult> CriarVendedor
        ([FromServices] AppDbContext context,
         [FromServices] IMapper mapper,
         [FromBody] CreateUsuarioDto usuarioDto)
        {

            if (usuarioDto is null)
            {
                return BadRequest("O usuário está nulo!!!");
            }
            Usuario usuario = mapper.Map<Usuario>(usuarioDto);

            usuario.Role = Role.Vendedor;
            await context.Usuarios.AddAsync(usuario);
            await context.SaveChangesAsync();
            return Ok(usuario);
        }

    }
}