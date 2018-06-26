using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
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
        public IWeatherService service { get; set; }
        public WeatherController controller { get; set; }

        [SetUp]
        public void SetUp()
        {
            this.service = new WeatherService();
            this.controller = new WeatherController(service);
        }

        [Test]
        public void SearchWithoutResults()
        {
            var wrongDataForSearch = "asdfasd";
            var acutalResult = service.GetSearchCityResult(wrongDataForSearch);
            var expectedResult = Array.Empty<CityDto>();

            Assert.That(acutalResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void EmptySearch()
        {
            var emptyString = string.Empty;
            var acutalResult = service.GetSearchCityResult(emptyString);

            Assert.That(acutalResult, Is.EqualTo(emptyString));
        }
    }
}
