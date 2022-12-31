using Microsoft.AspNetCore.Mvc;
using APP_API.Models;
using APP_API.Data;
using Microsoft.EntityFrameworkCore;

namespace APP_API.Controllers
{
    [ApiController]
    [Route("v1/usuario")]
    public class UsuarioController : ControllerBase
    {
        public UsuarioController()
        {
        }

        [HttpPost]
        [Route("criar")]
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
        [Route("{usuarioemail}")]
        public async Task<IActionResult> BuscarUsuario
        ([FromServices] AppDbContext context,
            [FromRoute] string usuarioemail)
        {
            var usuario = await context.
            Usuarios.
            AsNoTracking()
            .FirstOrDefaultAsync(x => x.Email.ToLower() == usuarioemail.ToLower()
            || x.NomeDeUsuario.ToLower() == usuarioemail.ToLower());
                return Ok(usuario);
        }
    }
}