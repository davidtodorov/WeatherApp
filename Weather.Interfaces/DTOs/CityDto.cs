namespace Weather.Interfaces.DTOs
{
    public class CityDto
    {
        public string Key { get; set; }

        public string LocalizedName { get; set; }

        public CountryDto Country { get; set; }
    }
}
