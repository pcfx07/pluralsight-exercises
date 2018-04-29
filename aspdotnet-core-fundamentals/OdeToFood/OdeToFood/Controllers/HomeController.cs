using Microsoft.AspNetCore.Mvc;

namespace OdeToFood.Controllers
{
    public class HomeController
    {
        // ENTRY POINT by convention
        public string Index()
        {
            // will be displayed in browser
            return "Hello from the HomeController";
        }
    }
}
