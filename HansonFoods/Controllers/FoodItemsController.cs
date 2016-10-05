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

        public ActionResult Index(int searchId)
        {
            var foodItems = GetFoodItems();

            if (searchId != 0)
            {
                foodItems = foodItems.Where(f => f.Id.Equals(searchId));
            }

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
            var foodItem = new FoodItem();
            
            return View("FoodForm", foodItem);
        }

        public ActionResult Edit(int id)
        {
            var foodItem = _context.FoodItems.SingleOrDefault(f => f.Id == id);

            if (foodItem == null)
            {
                return HttpNotFound();
            }

            return View("FoodForm", foodItem);
        }

        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(FoodItem foodItem)
        {
            //Form Validation
            if (!ModelState.IsValid)
            {
                return View("FoodForm",foodItem);
            }
            // New Customer
            if (foodItem.Id == 0)
            {
                _context.FoodItems.Add(foodItem);
            }
            else//Update Existing
            {
                var foodInDb = _context.FoodItems.Single(f => f.Id == foodItem.Id);

                // Doing individually to avoid magic string issues and potential security issues of TryUpdateModel
                // Could use Mapper and Dto if this were a larger project
                foodInDb.Name = foodItem.Name;
                foodInDb.Url = foodItem.Url;
                foodInDb.Email = foodItem.Email;
                foodInDb.Rating = foodItem.Rating;
            }

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