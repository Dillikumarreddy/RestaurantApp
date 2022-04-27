using System.ComponentModel.DataAnnotations;

namespace RestaurantApp.Models
{
    public class Restaurant
    {
        [Key]
        public int RestaurantId { get; set; }
        [Required]
        public string RestaurantName { get; set; }
        [Required]
        public string CityName { get; set; }
        [Required]
        [MinLength(10)]
        [MaxLength(10)]
        public string RestaurantPhone { get; set; }
        [Required]
        public int MinTime { get; set; }
        [Required]
        public string AreaName { get; set; }
        [Required]
        [MaxLength(6)]
        public string PinCode { get; set; }

        public string ContactName { get; set; }

        public int CostForTwo { get; set; }

        public string CoverPhoto { get; set; }

        public int CityId { get; set; }


    }
}
