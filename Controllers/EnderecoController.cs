using APP_API.Data;
using APP_API.Data.Dtos.EnderecoDto;
using APP_API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APP_API.Controllers
{
    [Route("endereco")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        [HttpPost]
        [Route("criar")]
        public async Task<IActionResult> CriarEndereco
            (
            [FromServices] AppDbContext context,
            [FromServices] IMapper mapper,
            [FromBody] CreateEnderecoDto enderecoDto
            )
        {
            
            if (enderecoDto is null)
                return BadRequest();

            Endereco endereco = mapper.Map<Endereco>(enderecoDto);

            await context.Enderecos.AddAsync(endereco);
            await context.SaveChangesAsync();
            return Ok(endereco);
        }

        [HttpGet]
        public async Task<IActionResult> BuscarEndereco([FromServices] AppDbContext context, [FromServices] IMapper mapper)
        {
            List<Endereco> enderecos = await context.Enderecos.ToListAsync();
            List<ReadEnderecoDto> enderecoDtos = mapper.Map<List<ReadEnderecoDto>>(enderecos);

            return Ok(enderecoDtos);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> BuscarEnderecoPorId
        (
            [FromServices] AppDbContext context,
            [FromServices] IMapper mapper,
            [FromRoute] int id
        )
        {
            var endereco = await context.Enderecos.FirstOrDefaultAsync(e => e.Id == id);

            if (endereco is null)
                    BadRequest();

            ReadEnderecoDto readEnderecoDto = mapper.Map<ReadEnderecoDto>(endereco);

            return Ok(readEnderecoDto);
        }
    }
}
