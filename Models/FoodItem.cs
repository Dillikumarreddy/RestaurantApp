using System.ComponentModel.DataAnnotations;

namespace RestaurantApp.Models
{
    public class FoodItem
    {  
        [Key]
        public int ItemId { get;set; }
        public int MenuId { get; set; }
        public string ItemName{ get; set; }

        public string ItemDescription { get; set; }

        public int? ItemPrice { get; set; }

        public string? IsVeg { get; set; }

        public string? ImgSource { get; set; }


    }
}
