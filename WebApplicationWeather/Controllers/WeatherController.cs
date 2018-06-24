using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using WebApplicationWeather.Models;

namespace WebApplicationWeather.Controllers
{
    public class WeatherController : Controller
    {

        public const string apikey  = "4LoYKmY4ze2F6ivayuqF73NtB5TmaBef";

        public IActionResult Search(CityViewModel city)
        {
            var endpoint = $"http://dataservice.accuweather.com/locations/v1/cities/autocomplete?apikey='{apikey}'&q='{city.Name}'";

            string s =
                " [{\"Version\":1,\"Key\":\"51536\",\"Type\":\"City\",\"Rank\":31,\"LocalizedName\":\"Varna\",\"Country\":{\"ID\":\"BG\",\"LocalizedName\":\"Bulgaria\"},\"AdministrativeArea\":{\"ID\":\"03\",\"LocalizedName\":\"Varna\"}},{\"Version\":1,\"Key\":\"208173\",\"Type\":\"City\",\"Rank\":75,\"LocalizedName\":\"Varnamkhvast\",\"Country\":{\"ID\":\"IR\",\"LocalizedName\":\"Iran\"},\"AdministrativeArea\":{\"ID\":\"04\",\"LocalizedName\":\"Esfahan\"}}] ";

            ////var result = DownloadPageAsync(endpoint);
            return this.Json(new { Result = s });
        }

        public IActionResult City(string cityId)
        {
            var endpoint = $"http://dataservice.accuweather.com//currentconditions/v1/'{cityId}'?apikey='{apikey}'&details=true";

            var tempResult = "[{\"LocalObservationDateTime\": \"2018-06-24T18:25:00+03:00\",\"EpochTime\": 1529853900,\"WeatherText\": \"Partly sunny\",\"WeatherIcon\": 3,\"IsDayTime\": true,\"Temperature\": {\"Metric\": {\"Value\": 20,\"Unit\": \"C\",\"UnitType\": 17},\"RelativeHumidity\": 59,\"DewPoint\": { \"Metric\": {\"Value\": 12.2,\"Unit\": \"C\",\"UnitType\": 17},\"Imperial\": {\"Value\": 54,\"Unit\":\"F\",\"UnitType\": 18}}}}]";

            return this.Json(new { result = tempResult});
        }

        private static async Task<string> DownloadPageAsync(string page)
        {
            // ... Use HttpClient.
            using (HttpContent content = new HttpClient().GetAsync(page).Result.Content)
            {
                // ... Read the string.
                return await content.ReadAsStringAsync();

            }
        }
    }
}