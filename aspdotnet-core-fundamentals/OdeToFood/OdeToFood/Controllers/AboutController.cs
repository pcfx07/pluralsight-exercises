using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Controllers
{
    //[Route("about")]
    //[Route("[controller]")]
    [Route("[controller]/[action]")]
    public class AboutController
    {
        //[Route("")]
        public string Phone() => "1234567890";

        //[Route("address")]
        public string Address() => "Germany";
    }
}
