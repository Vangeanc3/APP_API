using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            Usuario usuario = mapper.Map<Usuario>(usuarioDto);

            if (usuario is null)
            {
                return BadRequest();
            }

            usuario.Role = Role.Vendedor;
            await context.Usuarios.AddAsync(usuario);
            await context.SaveChangesAsync();
            return Ok(usuario);
        }

    }
}