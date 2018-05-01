using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Models;
using OdeToFood.Services;

namespace OdeToFood.Pages
{
    public class IndexModel : PageModel
    {
        private IRestaurantData _restaurantData;
        private IGreeter _greeter;

        public IEnumerable<Restaurant> Restaurants { get; set; }
        public string CurrentMessage { get; set; }

        public IndexModel(IRestaurantData restaurantData, IGreeter greeter)
        {
            _restaurantData = restaurantData;
            _greeter = greeter;
        }

        public void OnGet()
        {
            this.Restaurants = _restaurantData.GetAll();
            this.CurrentMessage = _greeter.GetMessageOfTheDay();
        }
    }
}