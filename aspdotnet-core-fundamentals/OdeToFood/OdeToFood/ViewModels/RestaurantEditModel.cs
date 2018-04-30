using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.ViewModels
{
    // OVERPOSTING: RECEIVING MORE INFO IN THE RESPONE AS EXPECTED
    // TO PREVENT IT WE CREATE A VIEWMODEL WITH JUST THE PROPERTIES WE NEED
    public class RestaurantEditModel
    {
        public string Name { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}
