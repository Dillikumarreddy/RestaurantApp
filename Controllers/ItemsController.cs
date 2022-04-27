using Microsoft.AspNetCore.Mvc;
using RestaurantApp.Models;

namespace RestaurantApp.Controllers
{
    public class ItemsController : Controller
    {
        static int tempDataRestId = 0;

        private ApplicationContext _context;
        public ItemsController(ApplicationContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Route("/Items/ItemsList/{restaurantId}")]
        public IActionResult ItemsList([FromRoute] int restaurantId)
        {
            //TempData["urlId"] = restaurantId;

            tempDataRestId = restaurantId;
            var x = _context.RestaurantMenu.Where(x => x.RestaurantId == restaurantId).ToList();
            List<FoodItem> foodItems = new List<FoodItem>();
            
             foreach (var i in x)
            {
                var y = _context.FoodItem.Where(a => a.MenuId == i.MenuId).ToList();
                foreach (var j in y)
                {
                    foodItems.Add(j);
                }
            }
            //int count=foodItems.Count();
            //for(int i = 0; i < count; i++)
            //{

            //}
            //TempData["RestData"] = foodItems;
            return View(foodItems);
           
        }





        [HttpPost]

        public IActionResult SearchByFilter(string search)
        {

            if(search==null)
            {
                return RedirectToAction("ItemsList", "Items", new { restaurantId = tempDataRestId });
            }
            //int restId =(int) TempData["urlId"];
            int restId = tempDataRestId;
            List<RestaurantMenu> restmenufromRestMenu = _context.RestaurantMenu.Where(r => r.RestaurantId == restId).ToList();
            List<FoodItem> itemsWithoutFilter=new List<FoodItem>();
            foreach(var item in restmenufromRestMenu)
            {
                var a =_context.FoodItem.Where(r => r.MenuId == item.MenuId).ToList();
                foreach (var j in a)
                {
                    itemsWithoutFilter.Add(j);
                }    
            }//unfiltereditems

            List<FoodItem> filteredItems = new List<FoodItem>();

            foreach(var k in itemsWithoutFilter)
            {
                if(k.ItemName.ToUpper().Contains(search.ToUpper()))
                {
                    filteredItems.Add(k);
                }
            }//filtereditems

            //var y = _context.FoodItem.Where(p => p.ItemName.ToUpper().Contains((search.ToUpper()))).ToList();//returns all items of search from db

            return View("ItemsList",filteredItems);
        }

        public IActionResult BackToRestaurant()
        {

            ViewBag.onBackId = tempDataRestId;
            return RedirectToAction("ItemsList","Items", new { restaurantId = tempDataRestId });
        }











    }
}
