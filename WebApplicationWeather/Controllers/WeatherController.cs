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
            string s =
                " [{\"Version\":1,\"Key\":\"51536\",\"Type\":\"City\",\"Rank\":31,\"LocalizedName\":\"Varna\",\"Country\":{\"ID\":\"BG\",\"LocalizedName\":\"Bulgaria\"},\"AdministrativeArea\":{\"ID\":\"03\",\"LocalizedName\":\"Varna\"}},{\"Version\":1,\"Key\":\"208173\",\"Type\":\"City\",\"Rank\":75,\"LocalizedName\":\"Varnamkhvast\",\"Country\":{\"ID\":\"IR\",\"LocalizedName\":\"Iran\"},\"AdministrativeArea\":{\"ID\":\"04\",\"LocalizedName\":\"Esfahan\"}}] ";

            //var result = DownloadPageAsync(page).Result;

            var cities = JsonConvert.DeserializeObject<List<CityModel>>(s);
            return this.Json(cities);
        }

        public IActionResult City(string cityId)
        {
            var page = "http://dataservice.accuweather.com//currentconditions/v1/" + cityId +"?apikey=" + apikey + "&details=true";

            var tempResult = "[{\"LocalObservationDateTime\":\"2018-06-25T15:05:00+03:00\",\"EpochTime\":1529928300,\"WeatherText\":\"Partly sunny\",\"WeatherIcon\":3,\"IsDayTime\":true,\"Temperature\":{\"Metric\":{\"Value\":23.9,\"Unit\":\"C\",\"UnitType\":17},\"Imperial\":{\"Value\":75.0,\"Unit\":\"F\",\"UnitType\":18}},\"RealFeelTemperature\":{\"Metric\":{\"Value\":24.1,\"Unit\":\"C\",\"UnitType\":17},\"Imperial\":{\"Value\":75.0,\"Unit\":\"F\",\"UnitType\":18}},\"RealFeelTemperatureShade\":{\"Metric\":{\"Value\":21.7,\"Unit\":\"C\",\"UnitType\":17},\"Imperial\":{\"Value\":71.0,\"Unit\":\"F\",\"UnitType\":18}},\"RelativeHumidity\":53,\"DewPoint\":{\"Metric\":{\"Value\":13.9,\"Unit\":\"C\",\"UnitType\":17},\"Imperial\":{\"Value\":57.0,\"Unit\":\"F\",\"UnitType\":18}},\"Wind\":{\"Direction\":{\"Degrees\":113,\"Localized\":\"ESE\",\"English\":\"ESE\"},\"Speed\":{\"Metric\":{\"Value\":25.9,\"Unit\":\"km/h\",\"UnitType\":7},\"Imperial\":{\"Value\":16.1,\"Unit\":\"mi/h\",\"UnitType\":9}}},\"WindGust\":{\"Speed\":{\"Metric\":{\"Value\":25.9,\"Unit\":\"km/h\",\"UnitType\":7},\"Imperial\":{\"Value\":16.1,\"Unit\":\"mi/h\",\"UnitType\":9}}},\"UVIndex\":5,\"UVIndexText\":\"Moderate\",\"Visibility\":{\"Metric\":{\"Value\":16.1,\"Unit\":\"km\",\"UnitType\":6},\"Imperial\":{\"Value\":10.0,\"Unit\":\"mi\",\"UnitType\":2}},\"ObstructionsToVisibility\":\"\",\"CloudCover\":35,\"Ceiling\":{\"Metric\":{\"Value\":9144.0,\"Unit\":\"m\",\"UnitType\":5},\"Imperial\":{\"Value\":30000.0,\"Unit\":\"ft\",\"UnitType\":0}},\"Pressure\":{\"Metric\":{\"Value\":1017.0,\"Unit\":\"mb\",\"UnitType\":14},\"Imperial\":{\"Value\":30.03,\"Unit\":\"inHg\",\"UnitType\":12}},\"PressureTendency\":{\"LocalizedText\":\"Steady\",\"Code\":\"S\"},\"Past24HourTemperatureDeparture\":{\"Metric\":{\"Value\":1.7,\"Unit\":\"C\",\"UnitType\":17},\"Imperial\":{\"Value\":3.0,\"Unit\":\"F\",\"UnitType\":18}},\"ApparentTemperature\":{\"Metric\":{\"Value\":24.4,\"Unit\":\"C\",\"UnitType\":17},\"Imperial\":{\"Value\":76.0,\"Unit\":\"F\",\"UnitType\":18}},\"WindChillTemperature\":{\"Metric\":{\"Value\":23.9,\"Unit\":\"C\",\"UnitType\":17},\"Imperial\":{\"Value\":75.0,\"Unit\":\"F\",\"UnitType\":18}},\"WetBulbTemperature\":{\"Metric\":{\"Value\":17.5,\"Unit\":\"C\",\"UnitType\":17},\"Imperial\":{\"Value\":63.0,\"Unit\":\"F\",\"UnitType\":18}},\"Precip1hr\":{\"Metric\":{\"Value\":0.0,\"Unit\":\"mm\",\"UnitType\":3},\"Imperial\":{\"Value\":0.0,\"Unit\":\"in\",\"UnitType\":1}},\"PrecipitationSummary\":{\"Precipitation\":{\"Metric\":{\"Value\":0.0,\"Unit\":\"mm\",\"UnitType\":3},\"Imperial\":{\"Value\":0.0,\"Unit\":\"in\",\"UnitType\":1}},\"PastHour\":{\"Metric\":{\"Value\":0.0,\"Unit\":\"mm\",\"UnitType\":3},\"Imperial\":{\"Value\":0.0,\"Unit\":\"in\",\"UnitType\":1}},\"Past3Hours\":{\"Metric\":{\"Value\":0.0,\"Unit\":\"mm\",\"UnitType\":3},\"Imperial\":{\"Value\":0.0,\"Unit\":\"in\",\"UnitType\":1}},\"Past6Hours\":{\"Metric\":{\"Value\":0.0,\"Unit\":\"mm\",\"UnitType\":3},\"Imperial\":{\"Value\":0.0,\"Unit\":\"in\",\"UnitType\":1}},\"Past9Hours\":{\"Metric\":{\"Value\":0.0,\"Unit\":\"mm\",\"UnitType\":3},\"Imperial\":{\"Value\":0.0,\"Unit\":\"in\",\"UnitType\":1}},\"Past12Hours\":{\"Metric\":{\"Value\":0.0,\"Unit\":\"mm\",\"UnitType\":3},\"Imperial\":{\"Value\":0.0,\"Unit\":\"in\",\"UnitType\":1}},\"Past18Hours\":{\"Metric\":{\"Value\":0.0,\"Unit\":\"mm\",\"UnitType\":3},\"Imperial\":{\"Value\":0.0,\"Unit\":\"in\",\"UnitType\":1}},\"Past24Hours\":{\"Metric\":{\"Value\":0.0,\"Unit\":\"mm\",\"UnitType\":3},\"Imperial\":{\"Value\":0.0,\"Unit\":\"in\",\"UnitType\":1}}},\"TemperatureSummary\":{\"Past6HourRange\":{\"Minimum\":{\"Metric\":{\"Value\":22.2,\"Unit\":\"C\",\"UnitType\":17},\"Imperial\":{\"Value\":72.0,\"Unit\":\"F\",\"UnitType\":18}},\"Maximum\":{\"Metric\":{\"Value\":23.9,\"Unit\":\"C\",\"UnitType\":17},\"Imperial\":{\"Value\":75.0,\"Unit\":\"F\",\"UnitType\":18}}},\"Past12HourRange\":{\"Minimum\":{\"Metric\":{\"Value\":12.2,\"Unit\":\"C\",\"UnitType\":17},\"Imperial\":{\"Value\":54.0,\"Unit\":\"F\",\"UnitType\":18}},\"Maximum\":{\"Metric\":{\"Value\":23.9,\"Unit\":\"C\",\"UnitType\":17},\"Imperial\":{\"Value\":75.0,\"Unit\":\"F\",\"UnitType\":18}}},\"Past24HourRange\":{\"Minimum\":{\"Metric\":{\"Value\":12.2,\"Unit\":\"C\",\"UnitType\":17},\"Imperial\":{\"Value\":54.0,\"Unit\":\"F\",\"UnitType\":18}},\"Maximum\":{\"Metric\":{\"Value\":23.9,\"Unit\":\"C\",\"UnitType\":17},\"Imperial\":{\"Value\":75.0,\"Unit\":\"F\",\"UnitType\":18}}}},\"MobileLink\":\"http://m.accuweather.com/en/bg/varna/51536/current-weather/51536?lang=en-us\",\"Link\":\"http://www.accuweather.com/en/bg/varna/51536/current-weather/51536?lang=en-us\"}]";

            //var result = DownloadPageAsync(page).Result;
            var weather = JsonConvert.DeserializeObject<List<WeatherModel>>(tempResult);
            return this.Json(weather);
        }

        

        private static async Task<string> DownloadPageAsync(string page)
        {
            // ... Use HttpClient.
            using (var response = new HttpClient().GetAsync(page).Result)
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return result;
                }
                return string.Empty;
            }
        }
    }
}