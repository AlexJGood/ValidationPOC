using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using ValidationPOC.BL;
using ValidationPOC.Domain;
using ValidationPOC.Model;
using ValidationPOC.ValidationService;

namespace ValidationPOC.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        readonly IForecastService _forecastService;
        readonly IValidationService _validationService;

        public WeatherForecastController( ILogger<WeatherForecastController> logger, IForecastService forecastService)
        {
            this._forecastService = forecastService;
            _logger = logger;
        }
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };


        [HttpGet]
        public ActionResult<Forecast> Get()
        {
            var rng = new Random();
            var forecast = new Forecast();
            forecast.Id = Guid.NewGuid();
            forecast.Name = "Rando week";
            forecast.Description = "Find the most current and reliable 7 day weather forecasts, storm alerts, reports and information for [city] with The Weather Network. ... Mock, WA Weather ...";

            forecast.ForecastDays = Enumerable.Range(1, 7).Select(index => {
                var lowTemperature = rng.Next(-20, 55);
                var highTempature = rng.Next(lowTemperature, 80);
                return new ForecastDay
                {
                    DayOfWeek = (ForecastDayOfWeek)index-1,
                    WeatherType = (WeatherType)rng.Next(0, 7),
                    LowTemperature = lowTemperature,
                    HighTemperature = highTempature,
                    Humidity = rng.Next(20, 80),
                    WindSpeed = rng.Next(0, 120)
                };
            }).ToArray();
            return forecast;
        }

        [HttpPost]
        public ActionResult Post(Forecast forecast)
        {
            return Ok();
        }

        [HttpPost("validate-lower")]
        public ActionResult PostValidateLower(ForecastRequest forecastRequest)
        {
            var forecast = new Forecast
            {
                Id = forecastRequest.Id,
                Name = forecastRequest.Name,
                Description = forecastRequest.Description,
                ForecastDays = forecastRequest.ForecastDays.Select(_ => new ForecastDay
                {
                    DayOfWeek = _.DayOfWeek,
                    WeatherType = _.WeatherType,
                    LowTemperature = _.LowTemperature,
                    HighTemperature = _.HighTemperature,
                    Humidity = _.Humidity,
                    WindSpeed = _.WindSpeed,
                }).ToArray()
            };

            var operationResult = _forecastService.Update(forecast);

            if (!operationResult.Success && !operationResult.ValidationResult.IsValid)
            {
                var problem = new ValidationProblemDetails(operationResult.ValidationResult.ValidationResults);
                problem.Status = 400;
                problem.Title = "There are some issues with your request";
                return BadRequest(problem);
            }
            return Ok();
        }
    }
}
