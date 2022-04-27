using System.ComponentModel.DataAnnotations;

namespace RestaurantApp.Models
{
    public class RestaurantMenu
    {
        [Key]
        public int MenuId { get; set; }

        public string MenuCategory { get; set; }
        
        public int RestaurantId { get; set; }

    }
}
