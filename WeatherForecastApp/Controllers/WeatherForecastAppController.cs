using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WeatherForecastApp.Models.WeatherForecastAppModels;
using WeatherForecastApp.Models.ApiResponseModels;
using WeatherForecastApp.Repositories;

namespace WeatherForecastApp.Controllers
{
    public class WeatherForecastAppController : Controller
    {
        private readonly IForecastRepository _forecastRepository;

        public WeatherForecastAppController()
            : this(new ForecastRepository())
        {

        }

        public WeatherForecastAppController(IForecastRepository forecastRepository)
        {
            this._forecastRepository = forecastRepository;
        }

        // GET: WeatherForecastApp/SearchCity
        public ActionResult SearchCity()
        {
            var viewModel = new SearchCity();
            return View(viewModel);
        }

        // POST: WeatherForecastApp/SearchCity
        [HttpPost]
        public ActionResult SearchCity(SearchCity model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("City", "WeatherForecastApp", new { city = model.CityName });
            }
            return View(model);
        }

        // GET: WeatherForecastApp/City
        public ActionResult City(string city)
        {
            WeatherResponse weatherResponse = _forecastRepository.GetForecast(city);
            City viewModel = new City();

            if (weatherResponse != null)
            {
                viewModel.Name = weatherResponse.Name;
                viewModel.Humidity = weatherResponse.Main.Humidity;
                viewModel.Pressure = weatherResponse.Main.Pressure;
                viewModel.Temp = weatherResponse.Main.Temp;
                viewModel.Weather = weatherResponse.Weather[0].Main;
                viewModel.Wind = weatherResponse.Wind.Speed;
            }
            return View(viewModel);
        }
    }
}