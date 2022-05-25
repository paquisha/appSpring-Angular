using ApiPeliculas.Entidades;
using Microsoft.EntityFrameworkCore;

namespace ApiPeliculas.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Genero> Generos { get; set; }
    }
}
