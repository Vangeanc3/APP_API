using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using APP_API.Data;
using APP_API.Data.Dtos.UsuarioDto;
using APP_API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
            Usuario user = mapper.Map<Usuario>(usuarioDto);

            user.Role = Role.Administrador;
            await context.Usuarios.AddAsync(user);
            await context.SaveChangesAsync();
            return Ok(user);
        }
    }
}