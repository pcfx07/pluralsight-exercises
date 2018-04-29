using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OdeToFood.Services;

namespace OdeToFood
{
    // Provides place to register your custom services to use with ASP.NET Core
    public class Startup
    {
        
        public void ConfigureServices(IServiceCollection services)
        {
            // Register custom services before using!
            services.AddSingleton<IGreeter, Greeter>();
            // reuse for one request
            services.AddScoped<IRestaurantData, InMemoryRestaurantData>();

            services.AddMvc();
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

            #region Serving Files
            //// tries to find default file and invokes StaticFiles middleware
            //// else forwards request to app.Run middleware
            //app.UseDefaultFiles();
            //app.UseStaticFiles();
            ////app.UseFileServer();
            #endregion

            app.UseStaticFiles();
            // use specific conventions, route requests through mvc framework
            //app.UseMvcWithDefaultRoute();

            // no default routes configured
            app.UseMvc(configureRoutes);

            app.Run(async (context) =>
            {
                #region Showing Exception Details
                //// PROVOKE EXCEPTION
                ////throw new Exception("error!");
                //int x = 4;
                //int divisionByZero = 5 / (x - 4);
                #endregion

                // Use an interface for further abstraction!
                var greeting = greeter.GetMessageOfTheDay();
                //await context.Response.WriteAsync($"{greeting} : {env.EnvironmentName}");
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync($"Not found!");
                logger.LogInformation("greeting handled!");
            });
        }

        private void configureRoutes(IRouteBuilder routeBuilder)
        {
            // /Home/Index (id is optional)
            routeBuilder.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}");
            //routeBuilder.MapRoute("About", "{controller}/{action=Address}");
        }
    }
}
