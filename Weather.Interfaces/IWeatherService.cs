using System;
using System.Collections;
using System.Collections.Generic;
using Weather.Interfaces.DTOs;

namespace Weather.Interfaces
{
    public interface IWeatherService
    {
        IList<CityDto> GetSearchCityResult(string cityName);

        IList<WeatherDto> GetWeatherDetails(string cityId);

        ForecastDto GetDailyForecast(string cityId);
    }
}
