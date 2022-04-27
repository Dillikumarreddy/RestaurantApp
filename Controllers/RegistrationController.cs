using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantApp.Models;
using System.Collections;
 using Microsoft.AspNetCore.Hosting;
using System.Web;

namespace RestaurantApp.Controllers
{
    public class RegistrationController : Controller
    {
        static int maxRestId ;
        static int maxMenuId ;
        static int maxItemId ;
        static int maxCityId;
        private readonly IWebHostEnvironment hostingEnvironment;

        private ApplicationContext _context;
        public RegistrationController(ApplicationContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            maxRestId = _context.Restaurant.Max(u => u.RestaurantId);
            maxMenuId = _context.RestaurantMenu.Max(u => u.MenuId);
            maxItemId = _context.FoodItem.Max(u => u.ItemId);
            maxCityId = _context.City.Max(u => u.CityId);
            this.hostingEnvironment = hostingEnvironment;
        }
        public IActionResult RegisterRestaurant()
        {

            return View();
        }

        public IActionResult SuccessMessage()
        {
            ViewBag.restId = _context.Restaurant.Max(u => u.RestaurantId);

            return PartialView("_Success");
        }


        public IActionResult FailureMessage()
        {
            return View("_Failure");
        }

        public IActionResult DynamicCheck()
        {
            return View();
        }




        //[HttpPost]

        //public IActionResult RegisterRestaurantSubmit(IFormCollection formCollection)
        //{
        //    //employee.Name = formCollection["Name"];
        //    Restaurant restaurant = new Restaurant();
        //    City city = new City();
        //    RestaurantMenu restaurantMenu = new RestaurantMenu();
        //    FoodItem foodItem = new FoodItem();

        //    List<FoodItem> foodItems = new List<FoodItem>();
        //    List<RestaurantMenu> restaurantMenuItems = new List<RestaurantMenu>();


        //    //var maxRestId= (from u in _context.Restaurant
        //    //                orderby u.RestaurantId descending
        //    //                select u.RestaurantId).Take(1);


        //    var maxRestId = _context.Restaurant.Max(u => u.RestaurantId);

        //    //var maxCityId = (from u in _context.City
        //    //                 orderby u.CityId descending
        //    //                 select u.CityId).Take(1);

        //    var maxCityId = _context.City.Max(u => u.CityId);


        //    //var maxItemId = (from u in _context.FoodItem
        //    //                 orderby u.ItemId descending
        //    //                 select u.ItemId).Take(1);
        //    var maxItemId = _context.FoodItem.Max(u => u.ItemId);

        //    //var maxMenuId = (from u in _context.RestaurantMenu
        //    //                 orderby u.MenuId descending
        //    //                 select u.MenuId).Take(1);
        //    var maxMenuId=_context.RestaurantMenu.Max(u => u.MenuId);

        //    restaurant.RestaurantName = formCollection["RestaurantName"];
        //    restaurant.CityName = formCollection["city"];
        //    restaurant.RestaurantPhone = formCollection["PhNo"];
        //    restaurant.MinTime = Convert.ToInt32(formCollection["MinTime"]);
        //    restaurant.AreaName = formCollection["Area"];
        //    restaurant.PinCode = formCollection["pincode"];
        //    restaurant.ContactName = formCollection["ContactName"];
        //    restaurant.CostForTwo = Convert.ToInt32(formCollection["CostForTwo"]);
        //    restaurant.CoverPhoto = formCollection["photo"];
        //    restaurant.RestaurantId = Convert.ToInt32(maxRestId)+1;
        //    restaurant.CityId = Convert.ToInt32(maxCityId) + 1;

        //    city.CityId = Convert.ToInt32(maxCityId)+1;
        //    city.CityName = formCollection["city"];
        //    city.PinCode = formCollection["pincode"];



        //    ArrayList fooditemsarray = new ArrayList();
        //    ArrayList descarray = new ArrayList();
        //    ArrayList urlarray = new ArrayList();
        //    ArrayList pricearray = new ArrayList();
        //    ArrayList isNonVegarray = new ArrayList();
        //    for(int i=1;i<=5;i++)
        //    {
        //        fooditemsarray.Add(formCollection["FoodName" + Convert.ToString(i) + Convert.ToString(1)]);
        //        fooditemsarray.Add(formCollection["FoodName" + Convert.ToString(i) + Convert.ToString(1)]);
        //        fooditemsarray.Add(formCollection["FoodName" + Convert.ToString(i) + Convert.ToString(1)]);
        //        fooditemsarray.Add(formCollection["FoodName" + Convert.ToString(i) + Convert.ToString(1)]);
        //        fooditemsarray.Add(formCollection["FoodName" + Convert.ToString(i) + Convert.ToString(1)]);
        //    }
        //    for (int i = 1; i <= 5; i++)
        //    {
        //        descarray.Add(formCollection["Description" + Convert.ToString(i) + Convert.ToString(2)]);
        //        descarray.Add(formCollection["Description" + Convert.ToString(i) + Convert.ToString(2)]);
        //        descarray.Add(formCollection["Description" + Convert.ToString(i) + Convert.ToString(2)]);
        //        descarray.Add(formCollection["Description" + Convert.ToString(i) + Convert.ToString(2)]);
        //        descarray.Add(formCollection["Description" + Convert.ToString(i) + Convert.ToString(2)]);
        //    }
        //    for (int i = 1; i <= 5; i++)
        //    {
        //        urlarray.Add(formCollection["photoUrl" + Convert.ToString(i) + Convert.ToString(3)]);
        //        urlarray.Add(formCollection["photoUrl" + Convert.ToString(i) + Convert.ToString(3)]);
        //        urlarray.Add(formCollection["photoUrl" + Convert.ToString(i) + Convert.ToString(3)]);
        //        urlarray.Add(formCollection["photoUrl" + Convert.ToString(i) + Convert.ToString(3)]);
        //        urlarray.Add(formCollection["photoUrl" + Convert.ToString(i) + Convert.ToString(3)]);
        //    }
        //    for (int i = 1; i <= 5; i++)
        //    {
        //        pricearray.Add(formCollection["Price" + Convert.ToString(i) + Convert.ToString(4)]);
        //        pricearray.Add(formCollection["Price" + Convert.ToString(i) + Convert.ToString(4)]);
        //        pricearray.Add(formCollection["Price" + Convert.ToString(i) + Convert.ToString(4)]);
        //        pricearray.Add(formCollection["Price" + Convert.ToString(i) + Convert.ToString(4)]);
        //        pricearray.Add(formCollection["Price" + Convert.ToString(i) + Convert.ToString(4)]);
        //    }
        //    for (int i = 1; i <= 5; i++)
        //    {
        //        isNonVegarray.Add(formCollection["IsNonVeg" + Convert.ToString(i) + Convert.ToString(5)]);
        //        isNonVegarray.Add(formCollection["IsNonVeg" + Convert.ToString(i) + Convert.ToString(5)]);
        //        isNonVegarray.Add(formCollection["IsNonVeg" + Convert.ToString(i) + Convert.ToString(5)]);
        //        isNonVegarray.Add(formCollection["IsNonVeg" + Convert.ToString(i) + Convert.ToString(5)]);
        //        isNonVegarray.Add(formCollection["IsNonVeg" + Convert.ToString(i) + Convert.ToString(5)]);
        //    }


        //    for (int i = 1; i <= 5; i++)
        //    {
        //        foodItem.ImgSource = urlarray[i].ToString();
        //        foodItem.ItemName = fooditemsarray[i].ToString();
        //        foodItem.IsVeg = isNonVegarray[i].ToString();
        //        foodItem.ItemPrice = (int)pricearray[i];
        //        foodItem.ItemDescription = descarray[i].ToString();



        //    }



        //    //for(int i=1;i<=5;i++)
        //    //{
        //    //    for (int j=1;j<=5;j++)
        //    //    {
        //    //        string checkFoodName = formCollection["FoodName" + Convert.ToString(i) + Convert.ToString(j)];
        //    //        string checkFoodDesc = formCollection["Description" + Convert.ToString(i) + Convert.ToString(j)];
        //    //        string checkURL = formCollection["photoUrl" + Convert.ToString(i) + Convert.ToString(j)];
        //    //        string checkFoodPrice = formCollection["Price" + Convert.ToString(i) + Convert.ToString(j)];
        //    //        string checkVegNV = formCollection["IsNonVeg" + Convert.ToString(i) + Convert.ToString(j)];

        //    //        if (j<3 && !checkFoodName.Equals(null) && !checkFoodDesc.Equals(null))
        //    //        {
        //    //            //restaurantMenu.RestaurantId = restaurant.RestaurantId;
        //    //            //restaurantMenu.
        //    //            foodItem.ItemId = Convert.ToInt32(maxItemId)+1;
        //    //            foodItem.ItemName = formCollection[checkFoodName]; 
        //    //            restaurantMenu.MenuId= Convert.ToInt32(maxMenuId) + 1;
        //    //            restaurantMenu.RestaurantId = restaurant.RestaurantId;
        //    //            foodItem.ItemDescription = formCollection[checkFoodDesc];

        //    //        }
        //    //        if (j>=3)
        //    //        {
        //    //            if(j==3 && !checkFoodName.Equals(null) && !checkFoodDesc.Equals(null))
        //    //            {
        //    //                foodItem.ItemPrice =Convert.ToInt32( formCollection[checkFoodPrice]);
        //    //                foodItem.ImgSource = formCollection[checkURL];

        //    //            }
        //    //            if (j == 4 && !checkFoodName.Equals(null) && !checkFoodDesc.Equals(null))
        //    //            {
        //    //                foodItem.ItemPrice = Convert.ToInt32(formCollection[checkFoodPrice]);
        //    //                foodItem.ImgSource = formCollection[checkURL];
        //    //            }
        //    //            if (j == 5 && !checkFoodName.Equals(null) && !checkFoodDesc.Equals(null))
        //    //            {
        //    //                foodItem.ItemPrice = Convert.ToInt32(formCollection[checkFoodPrice]);
        //    //                foodItem.ImgSource = formCollection[checkURL];
        //    //                restaurantMenu.MenuCategory = formCollection[checkURL];
        //    //            }

        //    //        }
        //    //    }

        //    //    foodItems.Add(foodItem);
        //    //    restaurantMenuItems.Add(restaurantMenu);
        //    //}




        //    if (foodItems.Count > 0)
        //    {
        //        _context.City.Add(city);
        //        _context.SaveChanges();
        //        _context.Restaurant.Add(restaurant);
        //        _context.SaveChanges();
        //        foreach (var x in foodItems)
        //        {
        //            _context.FoodItem.Add(x);
        //            _context.SaveChanges();
        //        }
        //        foreach (var y in restaurantMenuItems)
        //        {
        //            _context.RestaurantMenu.Add(y);
        //            _context.SaveChanges();
        //        }

        //    }


        //    var maxRestIdAfterSubmission = (from u in _context.Restaurant
        //                     orderby u.RestaurantId descending
        //                     select u.RestaurantId).Take(1);
        //    //string successCheck = _context.Restaurant.FirstOrDefault(x => x.RestaurantName == RestaurantName).RestaurantName;
        //    if(Convert.ToInt32(maxRestIdAfterSubmission)== restaurant.RestaurantId)
        //    {
        //        ViewBag.restId = maxRestIdAfterSubmission;
        //        return View("_Success");
        //    }
        //    else
        //    {
        //        return View("_Failure");
        //    }

        //    //if (successCheck.Length == 0)
        //    //{
        //    //    return View("_Failure");
        //    //}
        //    //else
        //    //{
        //    //    ViewBag.restId = RestaurantId;
        //    //    return View("_Success");
        //    //}
        //}



        [HttpPost]
        public IActionResult RegisterRestaurant(IFormCollection formCollection)
        {
            //formCollection.Keys------to get allkey values;
            IFormFile restimagefile = formCollection.Files["photo"];
            IFormFile itemimagefile1 = formCollection.Files["photoUrl13"];
            IFormFile itemimagefile2 = formCollection.Files["photoUrl23"];
            IFormFile itemimagefile3 = formCollection.Files["photoUrl33"];
            IFormFile itemimagefile4 = formCollection.Files["photoUrl43"];
            IFormFile itemimagefile5 = formCollection.Files["photoUrl53"];

            Restaurant restaurant = new Restaurant();
            FoodItem foodItem = new FoodItem();
            List<FoodItem> foodItems = new List<FoodItem>();
            RestaurantMenu restaurantMenu = new RestaurantMenu();
            City city = new City();
            FoodItem foodItem1 = new FoodItem();
            FoodItem foodItem2 = new FoodItem();
            FoodItem foodItem3 = new FoodItem();
            FoodItem foodItem4 = new FoodItem();
            FoodItem foodItem5 = new FoodItem();

            //var listOfFiles = Request.Form.Files;

            string uniqueFileName = null;
            string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
            uniqueFileName = Guid.NewGuid().ToString() + "_" + restimagefile.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            restimagefile.CopyTo(new FileStream(filePath, FileMode.Create));

            var restAreaName = (from cust in _context.Restaurant
                                where cust.RestaurantName == formCollection["RestaurantName"][0] && cust.AreaName == formCollection["Area"][0]
                                select cust.RestaurantId).ToList();//get the restaurantIds having same area and same name

            if (restAreaName.Count > 0)
            {
                return View("_ErrorRestArea");
            }

            ArrayList foodItemsRegistered = new ArrayList();

            for (int i = 1; i <= 5; i++)
            {
                string str1 = "FoodName" + Convert.ToString(i) + "1";
                if (formCollection[str1][0].Length > 0)
                {
                    foodItemsRegistered.Add(formCollection[str1][0]);
                }
            }
            ArrayList itemsWithoutDuplicates = new ArrayList();
            foreach (var item in foodItemsRegistered)
            {
                if (itemsWithoutDuplicates.Contains(item))
                {

                }
                else
                {
                    itemsWithoutDuplicates.Add(item);
                }
            }

            if (foodItemsRegistered.Count != itemsWithoutDuplicates.Count)
            {
                return View("_ErrorRestAreaFoodItem");

            }


            restaurant.CoverPhoto = uniqueFileName;
            restaurant.RestaurantName = formCollection["RestaurantName"];
            restaurant.AreaName = formCollection["Area"];
            restaurant.CityName = formCollection["city"];
            restaurant.ContactName = formCollection["ContactName"];
            restaurant.CostForTwo = Convert.ToInt32(formCollection["CostForTwo"]);
            restaurant.PinCode = formCollection["pincode"];
            restaurant.RestaurantPhone = formCollection["PhNo"];
            restaurant.MinTime = Convert.ToInt32(formCollection["MinTime"]);

            city.CityName = formCollection["city"];
            city.PinCode = formCollection["pincode"];





                if (itemimagefile1 is not null && formCollection["FoodName11"].ToString().Length>0 && formCollection["Description22"].ToString().Length > 0)
                {
                    foodItem1.ItemName = formCollection["FoodName11"];
                    foodItem1.ItemDescription = formCollection["Description12"];
                    if (itemimagefile1.FileName.Length> 0)
                    {
                    string uploadsFolder1 = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    string uniqueFileName1 = Guid.NewGuid().ToString() + "_" + itemimagefile1.FileName;
                    string filePath1 = Path.Combine(uploadsFolder1, uniqueFileName1);
                    itemimagefile1.CopyTo(new FileStream(filePath1, FileMode.Create));

                    foodItem1.ImgSource = uniqueFileName1;

                        //foodItem1.ImgSource = formCollection["photoUrl13"];
                    }
                    else
                    {
                        foodItem1.ImgSource = null;
                    }
                    if (formCollection["Price14"].ToString().Length > 0)
                    {

                        foodItem1.ItemPrice = Convert.ToInt32(formCollection["Price14"]);
                    }
                    else
                    {

                        foodItem1.ItemPrice = null;
                    }

                    if (formCollection["IsNonVeg15"].ToString().Length > 0)
                    {

                        foodItem1.IsVeg = formCollection["IsNonVeg15"];
                    }
                    else
                    {

                        foodItem1.IsVeg = null;
                    }
                    foodItems.Add(foodItem1);
                }
            


                if (itemimagefile2 is not null && formCollection["FoodName21"].ToString().Length > 0 && formCollection["Description22"].ToString().Length > 0)
                {
                    foodItem2.ItemName = formCollection["FoodName21"];
                    foodItem2.ItemDescription = formCollection["Description22"];

                if (itemimagefile2.FileName.Length > 0)
                {
                    string uploadsFolder2 = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    string uniqueFileName2 = Guid.NewGuid().ToString() + "_" + itemimagefile2.FileName;
                    string filePath2 = Path.Combine(uploadsFolder2, uniqueFileName2);
                    itemimagefile2.CopyTo(new FileStream(filePath2, FileMode.Create));

                    foodItem2.ImgSource = uniqueFileName2;
                        //foodItem2.ImgSource = formCollection["photoUrl23"];
                    }
                    else
                    {
                        foodItem2.ImgSource = null;
                    }
                    if (formCollection["Price24"].ToString().Length > 0)
                    {

                        foodItem2.ItemPrice = Convert.ToInt32(formCollection["Price24"]);
                    }
                    else
                    {
                        foodItem2.ItemPrice = null;
                    }

                    if (formCollection["IsNonVeg25"].ToString().Length > 0)
                    {

                        foodItem2.IsVeg = formCollection["IsNonVeg25"];
                    }
                    else
                    {

                        foodItem2.IsVeg = null;
                    }

                    foodItems.Add(foodItem2);
                }
            


            
                if (itemimagefile3 is not null && formCollection["FoodName31"].ToString().Length > 0 && formCollection["Description32"].ToString().Length > 0)
                {
                    foodItem3.ItemName = formCollection["FoodName31"];
                    foodItem3.ItemDescription = formCollection["Description32"];
                if (itemimagefile3.FileName.Length > 0)
                {
                    string uploadsFolder3 = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    string uniqueFileName3 = Guid.NewGuid().ToString() + "_" + itemimagefile3.FileName;
                    string filePath3 = Path.Combine(uploadsFolder3, uniqueFileName3);
                    itemimagefile3.CopyTo(new FileStream(filePath3, FileMode.Create));
                    foodItem3.ImgSource = uniqueFileName3;
                        //foodItem3.ImgSource = formCollection["photoUrl33"];
                    }
                    else
                    {
                        foodItem3.ImgSource = null;
                    }

                    if (formCollection["Price34"].ToString().Length > 0)
                    {

                        foodItem3.ItemPrice = Convert.ToInt32(formCollection["Price34"]);
                    }
                    else
                    {
                        foodItem3.ItemPrice = null;
                    }

                    if (formCollection["IsNonVeg35"].ToString().Length > 0)
                    {

                        foodItem3.IsVeg = formCollection["IsNonVeg35"];
                    }
                    else
                    {

                        foodItem3.IsVeg = null;
                    }

                    foodItems.Add(foodItem3);
                }
            


            
                if (itemimagefile4 is not null && formCollection["FoodName41"].ToString().Length > 0  && formCollection["Description42"].ToString().Length > 0)
                {
                    foodItem4.ItemName = formCollection["FoodName41"];
                    foodItem4.ItemDescription = formCollection["Description42"];
                if (itemimagefile4.FileName.Length > 0)
                {
                    string uploadsFolder4 = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    string uniqueFileName4 = Guid.NewGuid().ToString() + "_" + itemimagefile4.FileName;
                    string filePath4 = Path.Combine(uploadsFolder4, uniqueFileName4);
                    itemimagefile4.CopyTo(new FileStream(filePath4, FileMode.Create));
                    foodItem4.ImgSource = uniqueFileName4;
                        //foodItem4.ImgSource = formCollection["photoUrl43"];
                    }
                    else
                    {
                        foodItem4.ImgSource = null;
                    }

                    if (formCollection["Price44"].ToString().Length > 0)
                    {

                        foodItem4.ItemPrice = Convert.ToInt32(formCollection["Price44"]);
                    }
                    else
                    {

                        foodItem4.ItemPrice = null;
                    }

                    if (formCollection["IsNonVeg45"].ToString().Length > 0)
                    {

                        foodItem4.IsVeg = formCollection["IsNonVeg45"];
                    }
                    else
                    {
                        foodItem4.IsVeg = null;

                    }

                    foodItems.Add(foodItem4);
                }
            

           
                if (itemimagefile5 is not null && formCollection["FoodName51"].ToString().Length > 0 && formCollection["Description52"].ToString().Length > 0)
                {
                    foodItem5.ItemName = formCollection["FoodName51"];
                    foodItem5.ItemDescription = formCollection["Description52"];
                if (itemimagefile5.FileName.Length > 0)
                {
                    string uploadsFolder5 = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    string uniqueFileName5 = Guid.NewGuid().ToString() + "_" + itemimagefile5.FileName;
                    string filePath5 = Path.Combine(uploadsFolder5, uniqueFileName5);
                    itemimagefile5.CopyTo(new FileStream(filePath5, FileMode.Create));
                    foodItem5.ImgSource = uniqueFileName5;
                        //foodItem5.ImgSource = formCollection["photoUrl53"];
                    }
                    else
                    {
                        foodItem5.ImgSource = null;
                    }

                    if (formCollection["Price54"].ToString().Length > 0)
                    {

                        foodItem5.ItemPrice = Convert.ToInt32(formCollection["Price54"]);
                    }
                    else
                    {

                        foodItem5.ItemPrice = null;
                    }

                    if (formCollection["IsNonVeg55"].ToString().Length > 0)
                    {

                        foodItem5.IsVeg = formCollection["IsNonVeg55"];
                    }
                    else
                    {
                        foodItem5.IsVeg = null;

                    }

                    foodItems.Add(foodItem5);
                }
            

            var cityExist = _context.City.FirstOrDefault(x => x.CityName == city.CityName);
            if (cityExist != null)
            {
                restaurant.CityId = cityExist.CityId;

            }
            else
            {
                city.CityId = maxCityId + 1;
                _context.City.Add(city);
                _context.SaveChanges();
                restaurant.CityId = _context.City.Max(u => u.CityId);

            }
            restaurant.RestaurantId = maxRestId + 1;
            _context.Restaurant.Add(restaurant);
            _context.SaveChanges();

            for (int i = 0; i < foodItems.Count; i++)
            {
                int maxId = _context.RestaurantMenu.Max(u => u.MenuId);
                restaurantMenu.MenuId = maxId + 1;
                restaurantMenu.RestaurantId = _context.Restaurant.Max(u => u.RestaurantId);
                if (foodItems[i].IsVeg == "No")
                {
                    restaurantMenu.MenuCategory = "NV";

                }
                else
                {
                    restaurantMenu.MenuCategory = "V";
                }

                foodItem.MenuId = restaurantMenu.MenuId;
                foodItem.ImgSource = foodItems[i].ImgSource;
                foodItem.ItemName = foodItems[i].ItemName;
                foodItem.IsVeg = foodItems[i].IsVeg;
                foodItem.ItemDescription = foodItems[i].ItemDescription;
                foodItem.ItemPrice = foodItems[i].ItemPrice;
                int itId = _context.FoodItem.Max(u => u.ItemId);
                foodItem.ItemId = itId + 1;
                _context.RestaurantMenu.Add(restaurantMenu);
                _context.SaveChanges();
                _context.Entry(restaurantMenu).State = EntityState.Detached;
                _context.FoodItem.Add(foodItem);
                _context.SaveChanges();
                _context.Entry(foodItem).State = EntityState.Detached;


            }

            var newCityRow = _context.City.FirstOrDefault(x => x.CityName == formCollection["city"].ToString());
            if (newCityRow != null)
            {
                return RedirectToAction("SuccessMessage", "Registration");

            }
            else
            {
                return RedirectToAction("FailureMessage", "Registration");
            }
        }


    }
}
