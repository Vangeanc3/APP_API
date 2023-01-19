using APP_API.Data.Dtos.LinhaDto;
using APP_API.Data;
using APP_API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APP_API.Controllers
{
    [Route("api/[controller]")]
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

        [HttpGet]
        public async Task<IActionResult> BuscarLinhas([FromServices] AppDbContext context, [FromServices] IMapper mapper)
        {
            List<Linha> linhas = await context.Linhas.ToListAsync();
            List<ReadLinhaDto> linhasDto = mapper.Map<List<ReadLinhaDto>>(linhas);

            return Ok(linhasDto);
        }

        [HttpGet]
        [Route("{id}")]
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
    }
}
