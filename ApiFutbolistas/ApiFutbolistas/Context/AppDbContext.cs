
using ApiFutbolistas.Models;
using Microsoft.EntityFrameworkCore;


namespace ApiFutbolistas.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }
        public DbSet<Futbolista> futbolista { get; set; }
    }
}
