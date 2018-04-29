using Microsoft.Extensions.Configuration;

namespace OdeToFood.Services
{
    public interface IGreeter
    {
        string GetMessageOfTheDay();
    }

    // IConfiguration service already registered by default WebHostBuilder!
    public class Greeter : IGreeter
    {
        private IConfiguration _configuration;

        public Greeter(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetMessageOfTheDay()
        {
            return _configuration["Greeting"];
        }
    }
}