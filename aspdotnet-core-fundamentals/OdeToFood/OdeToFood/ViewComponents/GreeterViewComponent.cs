using Microsoft.AspNetCore.Mvc;
using OdeToFood.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.ViewComponents
{
    // VIEWCOMPONENTS USED INTERNALLY INSIDE OUR APP
    // USABLE FROM PARTIAL VIEWS, CONTENT VIEWS, LAYOUT VIEWS, RAZOR PAGES
    // ENCAPSULATED, CAN INJECT OWN SERVICES, OWN DATAACCESS
    // WITHOUT KNOWING IT'S PARENT VIEW/CONTROLLER

    // THIS IS A NAMING CONVENTION, THE FRAMEWORK FOLLOWS!
    public class GreeterViewComponent : ViewComponent
    {
        private IGreeter _greeter;

        public GreeterViewComponent(IGreeter greeter)
        {
            _greeter = greeter;
        }

        // CAN BE ASYNC OR ACCEPT PARAMETERS
        public IViewComponentResult Invoke()
        {
            var model = _greeter.GetMessageOfTheDay();
            // WILL RETURN ~/Views/Shared/Components/Greeter/Default.cshtml
            return View("Default", model);
        }
    }
}
