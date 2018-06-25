namespace WebApplicationWeather.Models
{
    public class CityModel
    {
        public string Key { get; set; }

        public string LocalizedName { get; set; }

        public CountryModel Country { get; set; }
    }
}
