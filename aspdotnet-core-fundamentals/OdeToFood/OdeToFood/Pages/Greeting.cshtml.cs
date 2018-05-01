using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Services;

namespace OdeToFood.Pages
{
    // CAN BE INSTANTIATED AND EXECUTED INSIDE OF UNIT-TESTS
    public class GreetingModel : PageModel
    {
        private IGreeter _greeter;

        public string CurrentGreeting { get; set; }

        // ON HTTP GET REQUEST, INSTANTIATE MODEL, INJECT SERVICES AND INVOKE onGet()
        public GreetingModel(IGreeter greeter)
        {
            _greeter = greeter;
        }

        // DIFFERENCE TO CONTROLLER:
        // CONTROLLER BUILDS A MODEL
        // THIS IS THE MODEL
        public void OnGet(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                CurrentGreeting = "Hello Unknown!";
                return;
            }
            CurrentGreeting = $"{name}: {_greeter.GetMessageOfTheDay()}";
        }
    }
}