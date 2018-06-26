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
            var cities = this.weatherService.GetSearchCityResult(city.Name);
            return this.Json(cities);
        }

        public IActionResult City(CityViewModel city)
        {
            var weather = this.weatherService.GetWeatherDetails(city.CityId);
            return this.Json(weather);
        }

        public IActionResult DailyForecast(CityViewModel city)
        {
            var forecast = this.weatherService.GetDailyForecast(city.CityId);
            return this.Json(forecast);
        }
    }
}