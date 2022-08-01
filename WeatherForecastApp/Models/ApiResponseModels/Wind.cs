using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherForecastApp.Models.ApiResponseModels
{
    public class Wind
    {
        public float Speed { get; set; }
        public int Deg { get; set; }
    }
}