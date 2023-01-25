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

            Orcamento orcamento = mapper.Map<Orcamento>(orcamentoDto);
           
            if (orcamento is null)
            {
                return BadRequest();
            }

            await context.Orcamentos.AddAsync(orcamento);
            await context.SaveChangesAsync();


            foreach (var produtodoorcamento in orcamentoDto.ProdutosDoOrcamento) // gambiarra!!!
            {
                var produtoid = produtodoorcamento.IdProduto;
                var produtoquant = produtodoorcamento.Quantidade;
                var detalheorcamentorequisicao = new DetalheOrcamento
                {
                    OrcamentoId = orcamento.Id,
                    ProdutoId = produtoid,
                    QuantProdutos = produtoquant
                };

                await context.DetalheOrcamento.AddAsync(detalheorcamentorequisicao);
            }


            await context.SaveChangesAsync();
            return Ok(orcamento);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> BuscarOrcamentoPorId
            (
                [FromServices] AppDbContext context,
                [FromServices] IMapper mapper,
                [FromRoute] int id
                
            )
        {
            var orcamento = context.Orcamentos.FirstOrDefault(orcamento => orcamento.Id == id);
            ReadOrcamentoDto orcamentoDto = mapper.Map<ReadOrcamentoDto>(orcamento);
            return Ok
                (
                new
                {
                    orcamentoDto.Id,
                    orcamentoDto.IdentificadorUnico,
                    orcamentoDto.NomeCliente,
                    orcamentoDto.DescricaoServico,
                    orcamentoDto.PrecoServico,
                    orcamentoDto.PrecoFinal,
                    instalador = new { orcamentoDto.Instalador.Nome, orcamentoDto.Instalador.Email },
                    produtos = orcamentoDto.DetalhesOrcamentos
                }
                );
        }
    }
}
