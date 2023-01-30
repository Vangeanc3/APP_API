using APP_API.Data.Dtos.DetalheOrcamentoDto;
using APP_API.Data.Dtos.OrcamentoDto;
using APP_API.Data;
using APP_API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APP_API.Controllers
{
    [Route("pedido")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        [HttpPost]
        [Route("criar")]
        public async Task<IActionResult> CriarPedido
        ([FromServices] AppDbContext context,
         [FromServices] IMapper mapper,
         [FromBody] CreatePedidoDto pedidoDto)
        {
            if (pedidoDto.ProdutosDoOrcamento is null)
            {
                return BadRequest("Um orçamento não pode ser feito, sem produtos");
            }

            Orcamento orcamento = mapper.Map<Orcamento>(pedidoDto);

            if (orcamento is null)
            {
                return BadRequest();
            }

            await context.Orcamentos.AddAsync(orcamento);
            await context.SaveChangesAsync();


            foreach (var produtodoorcamento in pedidoDto.ProdutosDoOrcamento) // gambiarra!!!
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


        [HttpPut]
        [Route("atualizar/{id}")]
        public async Task<IActionResult> AtualizarOrcamento
            (
                [FromServices] AppDbContext context,
                [FromServices] IMapper mapper,
                [FromRoute] int id,
                [FromBody] PutOrcamentoDto orcamentoDto
            )
        {
            Orcamento orcamento = mapper.Map<Orcamento>(orcamentoDto);

            if (orcamento == null)
            {
                return BadRequest();
            }

            var existeOrcamento = await context.Orcamentos.FindAsync(id);

            if (existeOrcamento is null)
            {
                return NotFound("O orcamento não existe");
            }


            existeOrcamento.NomeCliente = orcamento.NomeCliente != null ? orcamento.NomeCliente : existeOrcamento.NomeCliente;
            existeOrcamento.DescricaoServico = orcamento.DescricaoServico != null ? orcamento.DescricaoServico : existeOrcamento.DescricaoServico;
            existeOrcamento.PrecoServico = orcamento.PrecoServico != null ? orcamento.PrecoServico : existeOrcamento.PrecoServico;
            existeOrcamento.PrecoFinal = orcamento.PrecoFinal != null ? orcamento.PrecoFinal : existeOrcamento.PrecoFinal;
            existeOrcamento.InstaladorId = orcamento.InstaladorId != null ? orcamento.InstaladorId : existeOrcamento.InstaladorId;
            existeOrcamento.DetalhesOrcamentos = orcamento.DetalhesOrcamentos != null ? orcamento.DetalhesOrcamentos : existeOrcamento.DetalhesOrcamentos;

            context.Orcamentos.Update(existeOrcamento);
            await context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> BuscarOrcamentoPorId
            (
                [FromServices] AppDbContext context,
                [FromServices] IMapper mapper,
                [FromRoute] int? id

            )
        {
            if (id.HasValue)
            {
                var orcamento = await context.Orcamentos.FirstOrDefaultAsync(orcamento => orcamento.Id == id);

                ReadOrcamentoDto orcamentoDto = mapper.Map<ReadOrcamentoDto>(orcamento);

                if (orcamentoDto is null)
                {
                    return NotFound("Orçamento não existe");
                }

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
                            produtosDto = mapper.Map<List<ReadDetalheOrcamentoDto>>(orcamentoDto.DetalhesOrcamentos)
                        }
                    );
            }
            return BadRequest("Orçamento não existe");
        }

        [HttpDelete]
        [Route("deletar/{id}")]
        public async Task<IActionResult> DeletarOrcamento
       (
           [FromServices] AppDbContext context,
           [FromRoute] int id
       )
        {
            var orcamento = await context.Orcamentos.FindAsync(id);
            if (orcamento is null)
            {
                return NotFound();
            }

            context.Orcamentos.Remove(orcamento);
            await context.SaveChangesAsync();

            return Ok();
        }
    }
}
