using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using APP_API.Data;
using APP_API.Models;
using AutoMapper;
using APP_API.Data.Dtos.UsuarioDto;

namespace APP_API.Controllers
{
    [ApiController]
    [Route("instalador")]
    public class InstaladorController : ControllerBase
    {
        [HttpPost]
        [Route("criar")]
        public async Task<IActionResult> CriarInstalador
        ([FromServices] AppDbContext context,
         [FromServices] IMapper mapper,
        [FromBody] CreateUsuarioDto usuarioDto)
        {
            if (usuarioDto is null)
            {
                return BadRequest("O usuário está nulo!!!");
            }

            Usuario usuario = mapper.Map<Usuario>(usuarioDto);

            usuario.Role = Role.Instalador;
            await context.Usuarios.AddAsync(usuario);
            await context.SaveChangesAsync();
            return Ok(usuario);
        }























        [HttpGet]
        [Route("anonima")]
        [AllowAnonymous]
        public string Anonimo() => "Anônimo";

        [HttpGet]
        [Route("autenticado")]
        [Authorize]
        public string Autenticado() => $"Autenticado - {User.Identity.Name}";

        [HttpGet]
        [Route("instalador")]
        [Authorize(Roles = "Instalador")]
        public string Instalador() => $"Instalador";

        [HttpGet]
        [Route("vendedor")]
        [Authorize(Roles = "Vendedor")]
        public string Vendedor() => $"Vendedor";
    }
}