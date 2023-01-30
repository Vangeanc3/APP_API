using APP_API.Data;
using APP_API.Data.Dtos.CategoriaDto;
using APP_API.Data.Dtos.ProdutoDto;
using APP_API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpPut]
        [Route("atualizar/{id}")]
        public async Task<IActionResult> AtualizarLinha
              (
                  [FromServices] AppDbContext context,
                  [FromServices] IMapper mapper,
                  [FromRoute] int id,
                  [FromBody] PutProdutoDto putProdutoDto
              )
        {
            Produto produto = mapper.Map<Produto>(putProdutoDto);

            var existeProduto = await context.Produtos.FindAsync(id);

            if (existeProduto is null)
            {
                return NotFound("Produto não existe");
            }

            existeProduto.Nome = produto.Nome != null ? produto.Nome : existeProduto.Nome;
            existeProduto.Descricao = produto.Descricao != null ? produto.Descricao : existeProduto.Descricao;
            existeProduto.QuantEstoque = produto.QuantEstoque != null ? produto.QuantEstoque : existeProduto.QuantEstoque;
            existeProduto.PrecoCliente = produto.PrecoCliente != null ? produto.PrecoCliente : existeProduto.PrecoCliente;
            existeProduto.PrecoParceiro = produto.PrecoParceiro != null ? produto.PrecoParceiro : existeProduto.PrecoParceiro;
            existeProduto.LinkImg = produto.LinkImg != null ? produto.LinkImg : existeProduto.LinkImg;
            existeProduto.LinkPdfManual = produto.LinkPdfManual != null ? produto.LinkPdfManual : existeProduto.LinkPdfManual;
            existeProduto.CategoriaId = produto.CategoriaId != null ? produto.CategoriaId : existeProduto.CategoriaId;
            existeProduto.LinhaId = produto.LinhaId != null ? produto.LinhaId : existeProduto.LinhaId;

            context.Produtos.Update(existeProduto);
            await context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> BuscarProdutos([FromServices] AppDbContext context, [FromServices] IMapper mapper)
        {
            List<Produto> produtos = await context.Produtos.ToListAsync();
            List<ReadProdutoDto> produtosDto = mapper.Map<List<ReadProdutoDto>>(produtos);

            return Ok(produtosDto);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> BuscarProdutoPorId
      (
          [FromServices] AppDbContext context,
          [FromServices] IMapper mapper,
          [FromRoute] int id
      )
        {
            var produtos = await context.Produtos.FirstOrDefaultAsync(p => p.Id == id);

            if (produtos is null)
                BadRequest();

            ReadProdutoDto readProdutosDto = mapper.Map<ReadProdutoDto>(produtos);

            return Ok(readProdutosDto);
        }

         [HttpDelete]
        [Route("deletar/{id}")]
        public async Task<IActionResult> DeletarProduto
        (
            [FromServices] AppDbContext context,
            [FromQuery] int id
        )
        {
            var produto = await context.Produtos.FindAsync(id);
            if (produto is null)
            {
                return NotFound();
            }

            context.Produtos.Remove(produto);
            await context.SaveChangesAsync();

            return Ok();
        }

    }
}
