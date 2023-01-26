using APP_API.Data;
using APP_API.Data.Dtos.CategoriaDto;
using APP_API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Formats.Asn1;
using System.Reflection.Metadata.Ecma335;

namespace APP_API.Controllers
{
    [Route("categoria")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        [HttpPost]
        [Route("criar")]
        public async Task<IActionResult> CriarCategoria
        (
                [FromServices] AppDbContext context,
                [FromServices] IMapper mapper,
                [FromBody] CreateCategoriaDto categoriaDto
        )
        {

            if (categoriaDto is null)
                return BadRequest();

            Categoria categoria = mapper.Map<Categoria>(categoriaDto);

            await context.Categorias.AddAsync(categoria);
            await context.SaveChangesAsync();
            return Ok(categoria);
        } 

        [HttpGet]
        public async Task<IActionResult> BuscarCategorias([FromServices] AppDbContext context, [FromServices] IMapper mapper)
        {
            List<Categoria> categorias = await context.Categorias.ToListAsync();
            List<ReadLinhaDto> categoriaDto = mapper.Map<List<ReadLinhaDto>>(categorias);
            
            return Ok(categoriaDto);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> BuscarCategoriaPorId
        (
            [FromServices] AppDbContext context,
            [FromServices] IMapper mapper,
            [FromRoute] int id
        )
        {
            var categoria = await context.Categorias.FirstOrDefaultAsync(c => c.Id == id);

            if (categoria is null) 
                BadRequest();

            ReadLinhaDto categoriaDto = mapper.Map<ReadLinhaDto>(categoria);

            return Ok(categoriaDto);
        }
    }
}
