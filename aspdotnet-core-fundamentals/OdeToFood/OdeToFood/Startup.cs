using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

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
                              IGreeter greeter,
                              ILogger<Startup> logger)
        {
            #region using IApplicationBuilder
            //// only invoked once when framework is ready to setup the pipeline! 
            //// needs to return the middleware function to asp.net core
            //app.Use(next =>
            //{
            //    // invoked once per http request that reaches this middleware
            //    return async context =>
            //    {
            //        logger.LogInformation("request incoming!");
            //        if (context.Request.Path.StartsWithSegments("/mysegment"))
            //        {
            //            await context.Response.WriteAsync("Hit!");
            //            logger.LogInformation("request handled!");
            //        }
            //        else
            //        {
            //            // pass to next middleware
            //            await next(context);
            //            // after next, this is control flow going back out of the pipeline
            //            logger.LogInformation("request outgoing!");
            //        }
            //    };
            //});

            //app.UseWelcomePage(new WelcomePageOptions
            //{
            //    Path = "/wp"
            //});
            #endregion

            
            if (env.IsDevelopment())
            {
                // sits in front of the pipleline, allow all requests to flow through middleware
                // catches unhandled exception and prevents browser from receiving an empty response body
                // provides UI for developer
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                // PROVOKE EXCEPTION
                //throw new Exception("error!");
                int x = 4;
                int divisionByZero = 5 / (x - 4);

                // Use an interface for further abstraction!
                var greeting = greeter.GetMessageOfTheDay();
                await context.Response.WriteAsync(greeting);
                logger.LogInformation("greeting handled!");
            });
        }
    }
}
