using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace OdeToFood
{
    // Provides place to register your custom services to use with ASP.NET Core
    public class Startup
    {
        
        public void ConfigureServices(IServiceCollection services)
        {
            // Register custom services before using!
            services.AddSingleton<IGreeter, Greeter>();
        }

        // IApplicationBuilder etc. are already registered for us.
        // Setup HTTP processing pipeline used to respond to requests.
        public void Configure(IApplicationBuilder app, 
                              IHostingEnvironment env,
                              /*IConfiguration configuration*/
                              IGreeter greeter)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                //var greeting = configuration["Greeting"];

                // Use an interface for further abstraction!
                var greeting = greeter.GetMessageOfTheDay();
                await context.Response.WriteAsync(greeting);
            });
        }
    }
}
