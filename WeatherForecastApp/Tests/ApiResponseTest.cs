using NUnit.Framework;
using WeatherForecastApp.Repositories;
using WeatherForecastApp.Models.ApiResponseModels;

namespace WeatherForecastApp.Tests
{
    public class ApiResponseTest
    {
        private IForecastRepository _forecastRepository;

        [SetUp]
        public void Setup()
        {
            _forecastRepository = new ForecastRepository();
        }

        [Test]
        public void ApiResponse()
        {
            const string cityName = "Ankara";
            WeatherResponse apiResponse = _forecastRepository.GetForecast(cityName);

            Assert.AreEqual(apiResponse.Name, cityName);
        }
    }
}