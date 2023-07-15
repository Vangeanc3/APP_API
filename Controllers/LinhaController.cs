using APP_API.Data.Dtos.LinhaDto;
using APP_API.Data;
using APP_API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APP_API.Data.Dtos.EnderecoDto;

namespace APP_API.Controllers
{
    [Route("linha")]
    [ApiController]
    public class LinhaController : ControllerBase
    {
        [HttpPost]
        [Route("criar")]
        public async Task<IActionResult> CriarLinha
         ([FromServices] AppDbContext context,
          [FromServices] IMapper mapper,
          [FromBody] CreateLinhaDto linhaDto)
        {
            Linha linha = mapper.Map<Linha>(linhaDto);

            if (linha is null)
            {
                return BadRequest();
            }

            await context.Linhas.AddAsync(linha);
            await context.SaveChangesAsync();
            return Ok(linha);
        }

        [HttpPut]
        [Route("atualizar/{id}")]
        public async Task<IActionResult> AtualizarLinha
        (
            [FromServices] AppDbContext context,
            [FromServices] IMapper mapper,
            [FromRoute] int id,
            [FromBody] PutLinhaDto putLinhaDto
        )
        {
            Linha linha = mapper.Map<Linha>(putLinhaDto); 

            var existeLinha = await context.Linhas.FindAsync(id);

            if (existeLinha is null)
            {
                return NotFound("Linha não existe");
            }

            existeLinha.Nome = putLinhaDto.Nome != null ? putLinhaDto.Nome : existeLinha.Nome;
            existeLinha.CategoriaId = linha.CategoriaId != null ? linha.CategoriaId : existeLinha.CategoriaId;

            context.Linhas.Update(existeLinha);
            await context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        [Route("buscar")]
        public async Task<IActionResult> BuscarLinhas
        (
            [FromServices] AppDbContext context,
            [FromServices] IMapper mapper
        )
        {
            List<Linha> linhas = await context.Linhas.ToListAsync();
            List<ReadLinhaDto> linhasDto = mapper.Map<List<ReadLinhaDto>>(linhas);

            return Ok(linhasDto);
        }

        [HttpGet]
        [Route("buscar/parametro")]
        public async Task<IActionResult> BuscarLinhaPorId
        (
            [FromServices] AppDbContext context,
            [FromServices] IMapper mapper,
            [FromRoute] int id
        )
        {
            var linha = await context.Linhas.FirstOrDefaultAsync(l => l.Id == id);

            if (linha is null)
                BadRequest();

            ReadLinhaDto readLinhaDto = mapper.Map<ReadLinhaDto>(linha);

            return Ok(readLinhaDto);
        }

        [HttpDelete]
        [Route("deletar/{id}")]
        public async Task<IActionResult> DeletarLinha
        (
            [FromServices] AppDbContext context,
            [FromRoute] int id
        )
        {
            var linha = await context.Linhas.FindAsync(id);
            if (linha is null)
            {
                return NotFound();
            }

            context.Linhas.Remove(linha);
            await context.SaveChangesAsync();

            return Ok();
        }
    }
}
