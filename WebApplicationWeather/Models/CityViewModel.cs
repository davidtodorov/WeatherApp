using System.ComponentModel.DataAnnotations;

namespace WebApplicationWeather.Models
{
    public class CityViewModel
    {
        [Required]
        public string Name { get; set; }

        public string Country { get; set; }
    }
}
