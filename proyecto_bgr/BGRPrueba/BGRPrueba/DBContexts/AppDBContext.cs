using BGRPrueba.Model;
using Microsoft.EntityFrameworkCore;

namespace BGRPrueba.DBContexts;

public class AppDBContext : DbContext
{
    public AppDBContext(DbContextOptions<AppDBContext> options): base(options)
    {

    }
    public DbSet<Persona> Personas { get; set; }
}