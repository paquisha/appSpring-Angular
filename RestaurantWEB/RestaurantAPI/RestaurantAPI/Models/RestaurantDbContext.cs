using Microsoft.EntityFrameworkCore;

namespace RestaurantAPI.Models
{
    public class RestaurantDbContext: DbContext
    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options)
        {

        }

        public DbSet<Costumer> Costumers { get; set; }
        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<OrderMaster> OrderMaters { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
