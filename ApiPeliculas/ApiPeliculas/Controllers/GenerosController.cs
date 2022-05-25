using ApiPeliculas.Context;
using ApiPeliculas.DTOs;
using ApiPeliculas.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ApiPeliculas.Controllers
{
    [ApiController]
    [Route("api/generos")]
    public class GenerosController: ControllerBase
    {
        private readonly AppDbContext context;

        public GenerosController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Genero>>> Get()
        {
            return await context.Generos.ToListAsync();
        }
    }
}
