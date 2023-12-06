using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using System.Diagnostics.CodeAnalysis;

namespace NetWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
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

        [HttpGet("All")]
        public IEnumerable<WeatherForecast> GetWeatherForecast()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("Name")]
        public IEnumerable<WeatherForecast> GetWeatherForecast([FromQuery] string name)
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost]
        public IActionResult CreateWeatherForecast(WeatherForecast item)
        {
            return null;
        }

        [HttpPut]
        public IActionResult UpdateWeatherForecast(WeatherForecast item)
        {
            return null;
        }

        [HttpDelete("name/{name}/{city}")]
        public IActionResult DeleteWeatherForecast([FromRoute] string name, [FromRoute] string city)
        {
            return null;
        }

        [HttpGet("Test")]
        public IActionResult GetClubs()
        {
            List<Club> clubs = new List<Club>();
            clubs.Add(new Club
            {
                Name = "Club1",
                Birthday = new DateTime(1994, 2, 1),
                City = "Mendoza"
            });
            clubs.Add(new Club
            {
                Name = "Club2",
                Birthday = new DateTime(1992, 2, 1),
                City = "Córdoba"
            });
            clubs.Add(new Club
            {
                Name = "Club3",
                Birthday = new DateTime(1963, 2, 1),
                City = "Misiones"
            });
            clubs.Add(new Club
            {
                Name = "Club4",
                Birthday = new DateTime(1987, 2, 1),
                City = "Neuquen"
            });

            List<Club> result = clubs
                .Where(x => x.Birthday.Year > 1993)
                .ToList();

            List<Club> result1 = clubs
                .Where(Filter)
                .ToList();

            return Ok(result);
        }

        private bool Filter(Club club)
        {
            return club.Birthday.Year > 1993;
        }

        private List<Club> FilterOldSchool(List<Club> clubs)
        {
            List<Club> result = new List<Club>();

            foreach (Club club in clubs)
            {
                if (club.Birthday.Year > 1993)
                {
                    result.Add(club);
                }
            }

            return result;
        }

        private List<T> Where<T>(List<T> clubs, Func<T, bool> filter) 
        {
            List<T> result = new List<T>();

            foreach (T club in clubs)
            {
                if (filter(club))
                {
                    result.Add(club);
                }
            }

            return result;
        }
    }
}