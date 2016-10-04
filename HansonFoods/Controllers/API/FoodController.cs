using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HansonFoods.Models;

namespace HansonFoods.Controllers.API
{
    public class FoodController : ApiController
    {

        private ApplicationDbContext _context;

        public FoodController()
        {
            _context = new ApplicationDbContext();
        }
        
        // GET /api/food
        public IEnumerable<FoodItem> GetFoods()
        {
            return _context.FoodItems.ToList();
        }

        // GET .api/food/1
        public FoodItem GetFood(int id)
        {
            var foodItem = _context.FoodItems.SingleOrDefault(f => f.Id == id);

            if (foodItem == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return foodItem;

        }

        // POST /api/food
        [HttpPost]
        public FoodItem CreateFoodItem(FoodItem foodItem)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            _context.FoodItems.Add(foodItem);
            _context.SaveChanges();

            return foodItem;
        }

    }
}
