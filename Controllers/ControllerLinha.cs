using APP_API.Data.Dtos.CategoriaDto;
using APP_API.Data;
using APP_API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APP_API.Data.Dtos.LinhaDto;

namespace APP_API.Controllers
{
    [Route("linha")]
    [ApiController]
    public class ControllerLinha : ControllerBase
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
    }
}
