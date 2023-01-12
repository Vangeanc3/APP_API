using APP_API.Data;
using APP_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APP_API.Controllers
{
    [Route("endereco")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        [HttpPost]
        [Route("criar")]
        public async Task<IActionResult> CriarEndereco
            ([FromServices] AppDbContext context,
             Endereco endereco)
        {
            var e = endereco;

            if (e is null)
            {
                return BadRequest();
            }

            await context.Enderecos.AddAsync(e);
            await context.SaveChangesAsync();
            return Ok(endereco);
        }
    }
}
