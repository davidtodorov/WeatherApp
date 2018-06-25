using System;
using System.Web;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights.Extensibility.Implementation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RestSharp;
using WebApplicationWeather.Models;

namespace WebApplicationWeather.Controllers
{
    public class WeatherController : Controller
    {
        public const string apikey  = "JavnMvJ6GnJLdXQ9G1yUMHX8wHdXhNnB";

        public IActionResult Search(CityViewModel city)
        {
            var page = "http://dataservice.accuweather.com/locations/v1/cities/autocomplete?apikey=" + apikey + "&q=" + city.Name;
            string s =
                " [{\"Version\":1,\"Key\":\"51536\",\"Type\":\"City\",\"Rank\":31,\"LocalizedName\":\"Varna\",\"Country\":{\"ID\":\"BG\",\"LocalizedName\":\"Bulgaria\"},\"AdministrativeArea\":{\"ID\":\"03\",\"LocalizedName\":\"Varna\"}},{\"Version\":1,\"Key\":\"208173\",\"Type\":\"City\",\"Rank\":75,\"LocalizedName\":\"Varnamkhvast\",\"Country\":{\"ID\":\"IR\",\"LocalizedName\":\"Iran\"},\"AdministrativeArea\":{\"ID\":\"04\",\"LocalizedName\":\"Esfahan\"}}] ";

            var result = DownloadPageAsync(page).Result;
            return this.Json(result);
        }

        public IActionResult City(string cityId)
        {
            var page = "http://dataservice.accuweather.com//currentconditions/v1/" + cityId +"?apikey=" + apikey + "&details=true";

            var tempResult = "[{\"LocalObservationDateTime\": \"2018-06-24T18:25:00+03:00\",\"EpochTime\": 1529853900,\"WeatherText\": \"Partly sunny\",\"WeatherIcon\": 3,\"IsDayTime\": true,\"Temperature\": {\"Metric\": {\"Value\": 20,\"Unit\": \"C\",\"UnitType\": 17},\"RelativeHumidity\": 59,\"DewPoint\": { \"Metric\": {\"Value\": 12.2,\"Unit\": \"C\",\"UnitType\": 17},\"Imperial\": {\"Value\": 54,\"Unit\":\"F\",\"UnitType\": 18}}}}]";

            var result = DownloadPageAsync(page).Result;
            return this.Json(result);
        }

        private static async Task<string> DownloadPageAsync(string page)
        {
            // ... Use HttpClient.
            using (var response = new HttpClient().GetAsync(page).Result)
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                return string.Empty;
            }
        }
    }
}