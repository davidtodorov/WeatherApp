using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Weather.Interfaces;
using Weather.Interfaces.DTOs;

namespace Weather.Services
{
    public class WeatherService : IWeatherService
    {
        private const string apikey = "cxBNFzhzGrxxeK5LXH7m1k0zGjb5TD7b";

        public IList<CityDto> GetSearchCityResult(string cityName)
        {
            var page = "http://dataservice.accuweather.com/locations/v1/cities/autocomplete?apikey=" + apikey + "&q=" + cityName;
            var result = DownloadPageAsync(page).Result;
            var cities = JsonConvert.DeserializeObject<List<CityDto>>(result);

            return cities;
        }

        public IList<WeatherDto> GetWeatherDetails(string cityId)
        {
            var page = "http://dataservice.accuweather.com//currentconditions/v1/" + cityId + "?apikey=" + apikey + "&details=true";
            var result =  DownloadPageAsync(page).Result;
            var weather = JsonConvert.DeserializeObject<List<WeatherDto>>(result);

            return weather;
        }

        public ForecastDto GetDailyForecast(string cityId)
        {
            var page = "http://dataservice.accuweather.com/forecasts/v1/daily/1day/" + cityId + "?apikey=" + apikey + "&metric=true";
            var result = DownloadPageAsync(page).Result;
            var forecast = JsonConvert.DeserializeObject<ForecastDto>(result);

            return forecast;
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
                        //empty json for deserialize when there is no city/ies found
                        result = "[]";
                    }
                    return result;
                }
                return string.Empty;
            }
        }
    }
}
