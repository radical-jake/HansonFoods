using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HansonFoods.Models;

namespace HansonFoods.Controllers
{
    public class FoodItemsController : Controller
    {
        // GET: FoodItems
        public ActionResult Index()
        {
            var foodItems = GetFoodItems();
            return View(foodItems);
        }

        public ActionResult Details(int id)
        {
            var foodItem = GetFoodItems().SingleOrDefault(c => c.Id == id);

            if (foodItem == null)
                return HttpNotFound();

            return View(foodItem);
        }

        private IEnumerable<FoodItem> GetFoodItems()
        {
            return new List<FoodItem>
            {
                new FoodItem {Id = 1, Name = "Apple"},
                new FoodItem {Id = 2, Name = "Banana"}
            };
        }
    }
}