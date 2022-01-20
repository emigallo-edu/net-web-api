using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Clase1.Controllers
{
    [ApiController]
    [Route("WeatherForecast")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private List<WeatherForecast> _list;
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;

            var rng = new Random();
            this._list = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Id = index,
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToList();
        }

        [HttpGet]
        public List<WeatherForecast> Get()
        {
            return this._list;
        }

        [HttpGet]
        [Route("filter")]
        public IEnumerable<WeatherForecast> Get(int id)
        {
            return this._list.Where(x => x.Id == id).ToList();
        }

        [HttpPost]
        public IEnumerable<WeatherForecast> Insert(WeatherForecast item)
        {
            this._list.Add(item);
            return this._list;
        }

        [HttpDelete]
        public IEnumerable<WeatherForecast> Delete(int id)
        {
            WeatherForecast item = this._list.First(x => x.Id == id);
            this._list.Remove(item);
            return this._list;
        }
    }
}