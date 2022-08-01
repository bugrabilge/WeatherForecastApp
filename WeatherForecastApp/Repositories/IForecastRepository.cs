using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeatherForecastApp.Models.ApiResponseModels;

namespace WeatherForecastApp.Repositories
{
    public interface IForecastRepository
    {
        WeatherResponse GetForecast(string city);
    }
}