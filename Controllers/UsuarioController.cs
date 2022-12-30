using Microsoft.AspNetCore.Mvc;
using APP_API.Models;
using APP_API.Data;
using Microsoft.EntityFrameworkCore;

namespace APP_API.Controllers
{
    [ApiController]
    [Route("v1")]
    public class UsuarioController : ControllerBase
    {
        public UsuarioController()
        {
        }

        [HttpPost]
        public async Task<IActionResult> CriarUsuario
        ([FromServices] AppDbContext context,
        [FromBody]Usuario usuario)
        {
            Usuario user = usuario;

            if (user is null)
            {
                return BadRequest();
            }

            await context.Usuarios.AddAsync(user);
            await context.SaveChangesAsync();
            return Ok(user);
        }

        [HttpGet]
        [Route("v1/usuarios/{email}/{senha}")]
        public async Task<IActionResult> BuscarUsuario
        ([FromServices] AppDbContext context,
            [FromRoute] string email,
            [FromRoute] string senha)
        {
            var usuario = await context.
            Usuarios.
            AsNoTracking()
            .FirstOrDefaultAsync(x => x.Email.ToLower() == email.ToLower() 
                && x.Senha.ToLower() == senha.ToLower());

                return Ok(usuario);
        }
    }
}