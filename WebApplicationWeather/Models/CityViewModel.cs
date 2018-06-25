using System.ComponentModel.DataAnnotations;

namespace WebApplicationWeather.Models
{
    public class CityViewModel
    {
        public string CityId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
