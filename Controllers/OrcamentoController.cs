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
