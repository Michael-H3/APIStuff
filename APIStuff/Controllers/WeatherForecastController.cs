using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIStuff.Controllers
{
    /// <summary>
    /// API is MVC
    /// Model - yes
    /// view - no
    /// Controller - yes
    /// </summary>
    //Annotation eller en Attribute(data annotation) Et regelsæt til det der står nedenunder. Attribute er det mest brugte
    [ApiController]//annotation - explains that its a Controller and that modelbinding and modelstate is auto
    [Route("[controller]")]//annotation URL/URI- bestemmer hvordan din url ser ud. Tager WeatherForecast og sletter controller delen og det er så hvad siden hedder i URL'en
    [Route("api/WeatherForecast")]//gør det samme
    public class WeatherForecastController : ControllerBase //Controllers arver altid fra controllerbase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]//annotation som definerer i browseren at det næste der kommer er en Get metode. REST - film i morgen
        public IEnumerable<WeatherForecast> Get() //IENumerable er en liste/tæller Interface Så snart vi har noget med krokodillenæb har vi noget med generisk hvilket betyder man kan skrive hvad som helst
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
