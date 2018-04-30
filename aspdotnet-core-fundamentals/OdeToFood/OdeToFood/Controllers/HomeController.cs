using Microsoft.AspNetCore.Mvc;
using OdeToFood.Models;
using OdeToFood.Services;
using OdeToFood.ViewModels;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        private IRestaurantData _restaurantData;
        private IGreeter _greeter;

        public HomeController(IRestaurantData restaurantData, IGreeter greeter)
        {
            _restaurantData = restaurantData;
            _greeter = greeter;
        }

        // ENTRY POINT BY CONVENTION
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

            //var model = _restaurantData.GetAll();
            var model = new HomeIndexViewModel()
            {
                Restaurants = _restaurantData.GetAll(),
                CurrentMessage = _greeter.GetMessageOfTheDay()
            };

            // RENDER MODEL AS HTML
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = _restaurantData.Get(id);

            if (model == null)
            {
                //return NotFound();

                // 302, GOTO INDEX ACTION IN THE SAME CONTROLLER!
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        //ADD ROUTE CONSTRAINT TO PREVENT: AmbiguousActionException
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // ENSURES THAT WE HANDED OUT THIS FORM!
        public IActionResult Create(RestaurantEditModel model)
        {
            // TAGHELPERS WORK WITH MODELSTATE DATASTRUCT TO ASSOCIATE THE ERROR MESSAGES 
            // https://docs.microsoft.com/en-us/aspnet/core/mvc/models/validation?view=aspnetcore-2.1
            if (!ModelState.IsValid) return View();

            var newRestaurant = new Restaurant()
            {
                Name = model.Name,
                Cuisine = model.Cuisine
            };

            newRestaurant = _restaurantData.Add(newRestaurant);
            // DANGEROUS: WE ARE STILL IN THE POST OPERATION, SO A REFRESH WOULD
            // SEND ANOTHER POST REQUEST TO OUR SERVER. USE REDIRECT TO FORCE THE CLIENT
            // TO SEND A GET REQUEST
            //return View("Details", newRestaurant);

            // WILL CONSULT ROUTING RULES TO IDENTIFY Id PARAMETER AS THE LAST SEGMENT OF THE URL
            // EARCH VALUE THAT IS NOT IN THE ROUTING RULE WILL BE PUT IN THE QUERY STRING (see foo)
            return RedirectToAction(nameof(Details), new { Id = newRestaurant.Id, foo = "bar" });
        }
    }
}
