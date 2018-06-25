using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Weather.Interfaces;
using WebApplicationWeather.Models;

namespace WebApplicationWeather.Controllers
{
    public class WeatherController : Controller
    {
        private IWeatherService weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            this.weatherService = weatherService;
        }

        public IActionResult Search(CityViewModel city)
        {
            var result = this.weatherService.GetSearchCityResponse(city.Name);
            var cities = JsonConvert.DeserializeObject<List<CityDto>>(result);

            return this.Json(cities);
        }

        public IActionResult City(CityViewModel city)
        {
            var result = this.weatherService.GetWeatherDetails(city.CityId);
            var weather = JsonConvert.DeserializeObject<List<WeatherDto>>(result);

            return this.Json(weather);
        }
    }
}