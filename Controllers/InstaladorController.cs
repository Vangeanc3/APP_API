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
        public async Task<IActionResult> CriarUsuario
        ([FromServices] AppDbContext context,
        [FromBody] Instalador instalador)
        {
            Usuario user = instalador;
            user.Role = "Instalador";
            if (user is null)
            {
                return BadRequest();
            }
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