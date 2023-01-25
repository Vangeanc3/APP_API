using APP_API.Data.Dtos.ProdutoDto;
using APP_API.Data;
using APP_API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APP_API.Data.Dtos.OrcamentoDto;

namespace APP_API.Controllers
{
    [Route("orcamento")]
    [ApiController]
    public class OrcamentoController : ControllerBase
    {
        [HttpPost]
        [Route("criar")]
        public async Task<IActionResult> CriarOrcamento
        ([FromServices] AppDbContext context,
         [FromServices] IMapper mapper,
         [FromBody] CreateOrcamentoDto orcamentoDto)
        {
            if (orcamentoDto.ProdutosDoOrcamento is null)
            {
                return BadRequest("Um orçamento não pode ser feito, sem produtos");
            }

            foreach (var produtoDoOrcamento in orcamentoDto.ProdutosDoOrcamento) // GAMBIARRA!!!
            {
                var produtoId = produtoDoOrcamento.IdProduto;
                var produtoQuant = produtoDoOrcamento.Quantidade;
                var detalheOrcamentoRequisicao = new DetalheOrcamento
                {
                    OrcamentoId = orcamentoDto.IdentificadorUnico,
                    ProdutoId = produtoId,
                    QuantProdutos = produtoQuant
                };

                await context.DetalheOrcamento.AddAsync(detalheOrcamentoRequisicao);
                // await context.SaveChangesAsync();
            }

            Orcamento orcamento = mapper.Map<Orcamento>(orcamentoDto);

            if (orcamento is null)
            {
                return BadRequest();
            }


            await context.Orcamentos.AddAsync(orcamento);
            await context.SaveChangesAsync();
            return Ok(orcamento);
        }
    }
}
