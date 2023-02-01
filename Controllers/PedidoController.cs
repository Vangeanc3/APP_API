using APP_API.Data.Dtos.OrcamentoDto;
using APP_API.Data;
using APP_API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APP_API.Data.Dtos.PedidoDto;
using Microsoft.EntityFrameworkCore;
using APP_API.Data.Dtos.DetalhePedidoDto;

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
            if (pedidoDto.ProdutosDoPedido is null)
            {
                return BadRequest("Um pedido não pode ser feito, sem produtos");
            }

            Pedido pedido = mapper.Map<Pedido>(pedidoDto);

            if (pedido is null)
            {
                return BadRequest();
            }

            await context.Pedidos.AddAsync(pedido);
            await context.SaveChangesAsync();


            foreach (var produtosPedido in pedidoDto.ProdutosDoPedido) // gambiarra!!!
            {
                var produtoid = produtosPedido.ProdutoId;
                var produtoquant = produtosPedido.QuantProduto;
                var detalheProdutoRequisicao = new DetalheOrcamento
                {
                    OrcamentoId = pedido.Id,
                    ProdutoId = produtoid,
                    QuantProdutos = produtoquant
                };

                await context.DetalheOrcamento.AddAsync(detalheProdutoRequisicao);
            }


            await context.SaveChangesAsync();
            return Ok(pedido);
        }


        [HttpPut]
        [Route("atualizar/{id}")]
        public async Task<IActionResult> AtualizarPedido
            (
                [FromServices] AppDbContext context,
                [FromServices] IMapper mapper,
                [FromRoute] int id,
                [FromBody] PutPedidoDto pedidoDto
            )
        {
            Pedido pedido = mapper.Map<Pedido>(pedidoDto);

            if (pedido == null)
            {
                return BadRequest();
            }

            var existePedido = await context.Pedidos.FindAsync(id);

            if (existePedido is null)
            {
                return NotFound("O pedido não existe");
            }

            existePedido.EntregaOpcao = pedido.EntregaOpcao != null ? pedido.EntregaOpcao : existePedido.EntregaOpcao;
            existePedido.FormaDePagamento = pedido.FormaDePagamento != null ? pedido.FormaDePagamento : existePedido.FormaDePagamento;
            existePedido.Preco = pedido.Preco != null ? pedido.Preco : existePedido.Preco;
            existePedido.InstaladorId = pedido.InstaladorId != null ? pedido.InstaladorId : existePedido.InstaladorId;
            existePedido.DetalhePedidos = pedido.DetalhePedidos != null ? pedido.DetalhePedidos : existePedido.DetalhePedidos;
            

            context.Pedidos.Update(existePedido);
            await context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> BuscarPedidoPorId
            (
                [FromServices] AppDbContext context,
                [FromServices] IMapper mapper,
                [FromRoute] int? id

            )
        {
            if (id.HasValue)
            {
                var pedido = await context.Pedidos.FirstOrDefaultAsync(pedido => pedido.Id == id);

                ReadPedidoDto pedidoDto = mapper.Map<ReadPedidoDto>(pedido);

                if (pedidoDto is null)
                {
                    return NotFound("O Pedido não existe");
                }

                return Ok
                    (
                        new
                        {
                            pedidoDto.Id,
                            pedidoDto.Identificador,
                            pedidoDto.DetalhePedidos,
                            pedidoDto.EntregaOpcao,
                            pedidoDto.FormaDePagamento,
                            pedidoDto.Preco,
                            instalador = new { pedidoDto.Instalador.Nome, pedidoDto.Instalador.Email },
                            produtosDto = mapper.Map<List<ReadDetalhePedidoDto>>(pedidoDto.DetalhePedidos)
                        }
                    );
            }
            return BadRequest("O pedido não existe");
        }

        [HttpDelete]
        [Route("deletar/{id}")]
        public async Task<IActionResult> DeletarPedido
       (
           [FromServices] AppDbContext context,
           [FromRoute] int id
       )
        {
            var pedido = await context.Pedidos.FindAsync(id);
            if (pedido is null)
            {
                return NotFound();
            }

            context.Pedidos.Remove(pedido);
            await context.SaveChangesAsync();

            return Ok();
        }
    }
}
