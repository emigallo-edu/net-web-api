using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Calculator.Api.Controllers
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
            }).ToList();
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return this._list;
        }

        [HttpPut]
        public ObjectResult Insert(WeatherForecast item)
        {
            this._list.Add(item);
            return Ok(this._list);
        }

        [HttpPost]
        public void Update(WeatherForecast item)
        {

        }

        //[FromQuery]

        [HttpDelete]
        public void Delete(int id)
        {

        }
    }
}