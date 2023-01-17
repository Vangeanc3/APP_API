using APP_API.Data;
using APP_API.Data.Dtos.CategoriaDto;
using APP_API.Data.Dtos.ProdutoDto;
using APP_API.Models;
using AutoMapper;
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
        [HttpPost]
        [Route("criar")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> CriarProduto
           ([FromServices] AppDbContext context,
            [FromServices] IMapper mapper,
            [FromBody] CreateProdutoDto produtoDto)
        {
            Produto produto = mapper.Map<Produto>(produtoDto);


            if (produto is null)
            {
                return BadRequest();
            }

            await context.Produtos.AddAsync(produto);
            await context.SaveChangesAsync();
            return Ok(produto);
        }
    }
}
