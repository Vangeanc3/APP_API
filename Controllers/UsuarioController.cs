using Microsoft.AspNetCore.Mvc;
using APP_API.Models;
using APP_API.Data;
using Microsoft.EntityFrameworkCore;
using APP_API.Settings;

namespace APP_API.Controllers
{
    [ApiController]
    [Route("usuario")]
    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        [Route("{usuarioemail}")]
        public async Task<IActionResult> BuscarUsuario
        ([FromServices] AppDbContext context,
            [FromRoute] string usuarioemail)
        {
            var usuario = await context.
            Usuarios.
            AsNoTracking()
            .FirstOrDefaultAsync(x => x.Email.ToLower() == usuarioemail.ToLower());
                return Ok(usuario);
        }
    }
}