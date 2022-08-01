using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WeatherForecastApp.Models.WeatherForecastAppModels
{
    public class SearchCity
    {
        [Required(ErrorMessage = "*You must enter a city name!*")]
        [Display(Name = "City Name")]
        public string CityName { get; set; }
    }
}