namespace WebApplicationWeather.Models
{
    public class WeatherModel
    { 
        public int WeatherIcon { get; set; }

        public string WeatherText { get; set; }

        public TemperatureModel Temperature { get; set; }

        public int RelativeHumidity { get; set; }
    }
}
