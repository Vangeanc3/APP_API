using APP_API.Data;
using APP_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APP_API.Controllers
{
    [Route("produto")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        [HttpPost] // Definir quem vai criar o produto
        [Route("criar")]
        [Authorize(Roles = "Vendedor")]
        public async Task<IActionResult> CriarProduto
            ([FromServices] AppDbContext context,
             [FromBody] Produto produto)
        {
            var p = produto;

            if (p is null)
            {
                return BadRequest();
            } 

            await context.Produtos.AddAsync(p);
            await context.SaveChangesAsync();
            return Ok(produto);
        }
    }
}
