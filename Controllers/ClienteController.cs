using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APP_API.Data;
using APP_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace APP_API.Controllers
{
    [ApiController]
    [Route("cliente")]
    public class ClienteController : ControllerBase
    {
        [HttpPost]
        [Route("criar")]
        public async Task<IActionResult> CriarCliente
        ([FromServices] AppDbContext context,
        [FromBody]Usuario usuario)
        {
            Usuario user = usuario;

            if (user is null)
            {
                return BadRequest();
            }
            user.Role = Role.Cliente;
            await context.Usuarios.AddAsync(user);
            await context.SaveChangesAsync();
            return Ok(user);
        }
    }
}