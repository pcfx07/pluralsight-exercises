using Microsoft.AspNetCore.Mvc;
using OdeToFood.Models;
using OdeToFood.Services;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        private IRestaurantData _restaurantData;

        public HomeController(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }

        // ENTRY POINT by convention
        public IActionResult Index()
        {
            // will be displayed in browser
            //return "Hello from the HomeController";

            #region Action Results
            // CORE CONCEPT: seperate deciding what to do, from actual doing
            // action determines to return a content
            // later mvc takes that content result and turns it into http response
            //return Content("Hello from the HomeController");

            // something else later in the pipeline will figure out
            // what to do with this result
            //return new ObjectResult(model);
            #endregion

            //var model = new Restaurant
            //{
            //    Id = 1,
            //    Name = "Scott's Pizza Palace"
            //};
            var model = _restaurantData.GetAll();

            // RENDER MODEL AS HTML
            return View(model);
        }
    }
}
