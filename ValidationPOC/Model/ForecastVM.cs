using System;
using System.Text.Json.Serialization;
using ValidationPOC.Domain;

namespace ValidationPOC.Model
{
    public class ForecastRequest
    {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }

            public ForecastDayRequestItem[] ForecastDays
            {
                get; set;

            }
    }

    public class ForecastDayRequestItem
    {
        public int LowTemperature { get; set; }
        public int HighTemperature { get; set; }
        public int Humidity { get; set; }
        public int WindSpeed { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ForecastDayOfWeek DayOfWeek { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public WeatherType WeatherType { get; set; }
    }
}
