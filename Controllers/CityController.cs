using Microsoft.AspNetCore.Mvc;
using RestaurantApp.Models;

namespace RestaurantApp.Controllers
{
    public class CityController : Controller
    {
        private ApplicationContext _context;

        public CityController(ApplicationContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RestaurantsInCity(string city)
        {
            //    var x=from c in _context.City
            //          where c.CityName == city
            //          select c.CityId;

            //var x = _context.City.FirstOrDefault(x => x.CityName == city);
            //var y=_context.Restaurant.Where(a =>a.CityId== x.CityId).ToList();
            //    return View(y); 

            var x = _context.City.FirstOrDefault(x => x.CityName.ToLower() == city.ToLower());
            if (x != null)
            {
                var y = _context.Restaurant.Where(a => a.CityId == x.CityId).ToList();
                return View(y);
            }
            else
            {
                return View("Error");
            }

        }


    }
}
