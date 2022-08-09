using System.Text.Json.Serialization;

namespace ExperianWeather.API.Model
{
    public class WeatherModel
    {
        [JsonPropertyName("location")]
        public LocationModel LocationDetails { get; set; }
        [JsonPropertyName("current")]
        public TempratureModel CurrentDetails { get; set; }  
    }
}
