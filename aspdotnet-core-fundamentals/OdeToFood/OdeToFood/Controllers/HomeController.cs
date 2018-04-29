using Microsoft.AspNetCore.Mvc;
using OdeToFood.Models;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        // ENTRY POINT by convention
        public IActionResult Index()
        {
            // will be displayed in browser
            //return "Hello from the HomeController";

            // CORE CONCEPT: seperate deciding what to do, from actual doing
            // action determines to return a content
            // later mvc takes that content result and turns it into http response
            //return Content("Hello from the HomeController");

            var model = new Restaurant
            {
                Id = 1,
                Name = "Scott's Pizza Palace"
            };

            // something else later in the pipeline will figure out
            // what to do with this result
            return new ObjectResult(model);
        }
    }
}
