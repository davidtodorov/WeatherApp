using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp.Extensions;
using Weather.Interfaces;
using Weather.Interfaces.DTOs;
using Weather.Services;
using WebApplicationWeather.Controllers;
using WebApplicationWeather.Models;

namespace Weather.Tests
{
    [TestFixture]
    public class WeatherTests
    {
        private IWeatherService service { get; set; }
        private WeatherController controller { get; set; }
        private CityViewModel city { get; set; }

        [SetUp]
        public void SetUp()
        {
            this.service = new WeatherService();
            this.controller = new WeatherController(service);
            this.city = new CityViewModel();
        }

        [Test]
        public void SearchWithoutResults()
        {
            var wrongDataForSearch = "asdfadadf";
            city.CityId = wrongDataForSearch;

            var actualResult = service.GetSearchCityResult(wrongDataForSearch);
            var expectedResult = Array.Empty<CityDto>();

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void EmptySearch()
        {
            var emptyString = string.Empty;
            var acutalResult = service.GetSearchCityResult(emptyString);
            var expectedResult = Array.Empty<CityDto>();

            Assert.That(acutalResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void CityDetailsWithNotCityKey()
        {
            var wrongCityKey = "234234234234";
            var acutalResult = service.GetWeatherDetails(wrongCityKey);
            Assert.That(acutalResult, Is.Null);
        }

        [Test]
        public void ForecastWithNotValidCityKey()
        {
            var notValidKey = 111111111111111.ToString();
            var actualResult = service.GetDailyForecast(notValidKey);

            Assert.That(actualResult, Is.Null);
        }
    }
}
