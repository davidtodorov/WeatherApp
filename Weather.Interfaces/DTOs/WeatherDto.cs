namespace Weather.Interfaces.DTOs
{
    public class WeatherDto
    { 
        public int WeatherIcon { get; set; }

        public string WeatherText { get; set; }

        public TemperatureDto Temperature { get; set; }

        public int RelativeHumidity { get; set; }
    }
}
