using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Weather.Interfaces;

namespace Weather.Services
{
    public class WeatherService : IWeatherService
    {
        private const string apikey = "fGMDhJfXeGJBUgpqLTEoCgFn8jUAD2z8";

        public string GetSearchCityResponse(string cityName)
        {
            var page = "http://dataservice.accuweather.com/locations/v1/cities/autocomplete?apikey=" + apikey + "&q=" + cityName;
            return  DownloadPageAsync(page).Result;
        }

        public string GetWeatherDetails(string cityId)
        {
            var page = "http://dataservice.accuweather.com//currentconditions/v1/" + cityId + "?apikey=" + apikey + "&details=true";
            return DownloadPageAsync(page).Result;
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
