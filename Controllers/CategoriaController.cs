﻿using APP_API.Data;
using APP_API.Data.Dtos.CategoriaDto;
using APP_API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APP_API.Controllers
{
    [Route("categoria")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        [HttpPost]
        [Route("criar")]
        [Authorize(Roles = "Administrador")]
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

        [HttpPut]
        [Route("atualizar/{id}")]
        public async Task<IActionResult> AtualizarCategoria
          (
              [FromServices] AppDbContext context,
              [FromServices] IMapper mapper,
              [FromRoute] int id,
              [FromBody] PutCategoriaDto categoriaDto
          )
        {

            var existeCategoria = await context.Categorias.FindAsync(id);

            if (existeCategoria is null)
            {
                return NotFound("Categoria não existe");
            }


            existeCategoria.Nome = categoriaDto.Nome != null ? categoriaDto.Nome : existeCategoria.Nome;

            context.Categorias.Update(existeCategoria);
            await context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        [Route("buscar")]
        public async Task<IActionResult> BuscarCategorias([FromServices] AppDbContext context, [FromServices] IMapper mapper)
        {
            List<Categoria> categorias = await context.Categorias.ToListAsync();
            List<ReadCategoriaDto> categoriaDto = mapper.Map<List<ReadCategoriaDto>>(categorias);

            return Ok(categoriaDto);
        }

        [HttpGet]
        [Route("buscar/parametro")]
        public async Task<IActionResult> BuscarCategoriaPorId
        (
            [FromServices] AppDbContext context,
            [FromServices] IMapper mapper,
            [FromQuery] int id
        )
        {
            var categoria = await context.Categorias.FirstOrDefaultAsync(c => c.Id == id);

            if (categoria is null)
            {
                BadRequest();
            }

            ReadCategoriaDto categoriaDto = mapper.Map<ReadCategoriaDto>(categoria);

            return Ok(categoriaDto);
        }

        [HttpDelete]
        [Route("deletar/{id}")]
        public async Task<IActionResult> DeletarCategoria
                (
                    [FromServices] AppDbContext context,
                    [FromRoute] int id
                )
        {
            var categoria = await context.Categorias.FindAsync(id);
            if (categoria is null)
            {
                return NotFound();
            }

            context.Categorias.Remove(categoria);
            await context.SaveChangesAsync();

            return Ok();
        }

    }
}
