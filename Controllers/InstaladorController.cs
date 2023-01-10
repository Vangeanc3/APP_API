using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using APP_API.Data;
using APP_API.Models;

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
        [FromBody]Usuario usuario)
        {
            Usuario user = usuario;

            if (user is null)
            {
                return BadRequest();
            }

            user.Role = Role.Instalador;
            await context.Usuarios.AddAsync(user);
            await context.SaveChangesAsync();
            return Ok(user);
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