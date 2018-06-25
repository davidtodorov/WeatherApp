using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

using WebApplicationWeather.Models;

namespace WebApplicationWeather.Controllers
{
    public class WeatherController : Controller
    {
        public const string apikey  = "fGMDhJfXeGJBUgpqLTEoCgFn8jUAD2z8";

        public IActionResult Search(CityViewModel city)
        {
            var page = "http://dataservice.accuweather.com/locations/v1/cities/autocomplete?apikey=" + apikey + "&q=" + city.Name;

            var result = DownloadPageAsync(page).Result;

            var cities = JsonConvert.DeserializeObject<List<CityDto>>(result);
            return this.Json(cities);
        }

        public IActionResult City(CityViewModel city)
        {
            var page = "http://dataservice.accuweather.com//currentconditions/v1/" + city.CityId +"?apikey=" + apikey + "&details=true";

            var result = DownloadPageAsync(page).Result;
            var weather = JsonConvert.DeserializeObject<List<WeatherDto>>(result);
            return this.Json(weather);
        }

        private static async Task<string> DownloadPageAsync(string page)
        {
            using (var response = new HttpClient().GetAsync(page).Result)
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    if (result == "")
                    {
                        result = "[]";
                    }
                    return result;
                }
                return string.Empty;
            }
        }
    }
}