using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace OdeToFood
{
    public class Program
    {
        // ENTRY POINT
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        // IIS acts as a proxy for our Webhost, forwards requests into app.
        // App has it's own webserver which is configured here.
        // 1. will use cross-plattform Kestrel webserver
        // 2. IIS integration
        // 3. logging
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
