﻿using APP_API.Data;
using APP_API.Data.Dtos.CategoriaDto;
using APP_API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APP_API.Controllers
{
    [Route("categoria")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        [HttpPost]
        [Route("criar")]
        public async Task<IActionResult> CriarCategoria
            ([FromServices] AppDbContext context,
             [FromServices] IMapper mapper,
             [FromBody] CreateCategoriaDto categoriaDto)
        {
            Categoria categoria = mapper.Map<Categoria>(categoriaDto);


            if (categoria is null)
            {
                return BadRequest();
            }

            await context.Categorias.AddAsync(categoria);
            await context.SaveChangesAsync();
            return Ok(categoria);
        }
    }
}
