using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HansonFoods.Enums;
using HansonFoods.Models;

namespace HansonFoods.Controllers
{
    public class FoodItemsController : Controller
    {
        private ApplicationDbContext _context;

        public FoodItemsController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var foodItems = GetFoodItems();
            return View(foodItems);
        }

        public ActionResult Details(int id)
        {
            var foodItem = GetFoodItems().SingleOrDefault(f => f.Id == id);

            if (foodItem == null)
                return HttpNotFound();

            return View(foodItem);
        }

        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FoodItem foodItem)
        {
            _context.FoodItems.Add(foodItem);
            _context.SaveChanges();

            return RedirectToAction("Index", "FoodItems");
        }


        //-------------------Helpers
        private IEnumerable<FoodItem> GetFoodItems()
        {
            var foodItems = _context.FoodItems.ToList();
            return foodItems;

            // First hardcoded List for initial testing
            /*
             * return new List<FoodItem>
            {
                new FoodItem {Id = 1, Name = "Apple", Rating = RatingEnum.Bad},
                new FoodItem {Id = 2, Name = "Banana"}
            };*/
        }
    }
}