using System;

namespace Weather.Interfaces
{
    public interface IWeatherService
    {
        string GetSearchCityResponse(string cityName);

        string GetWeatherDetails(string cityId);
    }
}
