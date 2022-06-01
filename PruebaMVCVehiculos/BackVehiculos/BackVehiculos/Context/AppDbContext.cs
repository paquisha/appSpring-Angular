using BackVehiculos.Models;
using Microsoft.EntityFrameworkCore;

namespace BackVehiculos.Context
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Vehiculo> Vehiculos { get; set; }
    }
}
