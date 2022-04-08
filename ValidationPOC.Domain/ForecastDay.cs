using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ValidationPOC.Domain
{
    public class ForecastDay
    {
        [Required]
        [Range(-20,120)]
        public int LowTemperature { get; set; }
        [Required]
        [Range(-20, 120)]
        public int HighTemperature { get; set; }
        [Required]
        [Range(0, 100)]
        public int Humidity { get; set; }
        [Required]
        [Range(0, 200)]
        public int WindSpeed { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ForecastDayOfWeek DayOfWeek { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public WeatherType WeatherType { get; set; }
    }
}
