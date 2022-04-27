using Microsoft.EntityFrameworkCore;

namespace RestaurantApp.Models
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
        public DbSet<FoodItem> FoodItem { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Restaurant> Restaurant { get; set; }
        public DbSet<RestaurantMenu> RestaurantMenu { get; set; }

    }
}
