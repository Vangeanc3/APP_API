using APP_API.Data;
using APP_API.Data.Dtos.CategoriaDto;
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


        [HttpPut]
        [Route("atualizar/{id}")]
        public async Task<IActionResult> AtualizarEndereco
          (
              [FromServices] AppDbContext context,
              [FromServices] IMapper mapper,
              [FromRoute] int id,
              [FromBody] PutEnderecoDto enderecoDto
          )
        {
            Endereco endereco = mapper.Map<Endereco>(enderecoDto);

            var existeEndereco = await context.Enderecos.FindAsync(id);

            if (existeEndereco is null)
            {
                return NotFound("Endereço não existe");
            }

            existeEndereco.Cep = endereco.Cep != null ? endereco.Cep : existeEndereco.Cep;
            existeEndereco.Bloco = endereco.Bloco != null ? endereco.Bloco : existeEndereco.Bloco;
            existeEndereco.Numero = endereco.Numero != null ? endereco.Numero : existeEndereco.Numero;
            existeEndereco.Bairro = endereco.Bairro != null ? endereco.Bairro : existeEndereco.Bairro;
            existeEndereco.Apartamento = endereco.Apartamento != null ? endereco.Apartamento : existeEndereco.Apartamento;
            existeEndereco.Rua = endereco.Rua != null ? endereco.Rua : existeEndereco.Rua;

            context.Enderecos.Update(existeEndereco);
            await context.SaveChangesAsync();

            return NoContent();
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

        [HttpDelete]
        [Route("deletar/{id}")]
        public async Task<IActionResult> DeletarEndereco
        (
            [FromServices] AppDbContext context,
            [FromQuery] int id
        )
        {
            var endereco = await context.Enderecos.FindAsync(id);
            if (endereco is null)
            {
                return NotFound();
            }

            context.Enderecos.Remove(endereco);
            await context.SaveChangesAsync();

            return Ok();
        }
    }
}
