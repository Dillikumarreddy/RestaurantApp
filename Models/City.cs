using System.ComponentModel.DataAnnotations;

namespace RestaurantApp.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        public string CityName{ get; set; }
        public string PinCode { get; set; }
    }
}
