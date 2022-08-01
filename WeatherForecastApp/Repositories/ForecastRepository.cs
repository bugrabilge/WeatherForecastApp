using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using WeatherForecastApp.Models.ApiResponseModels;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace WeatherForecastApp.Repositories
{
    public class ForecastRepository : IForecastRepository
    {
        WeatherResponse IForecastRepository.GetForecast(string city)
        {
            string apiKey = Constants.API_Key;
            
            // Connection String
            var client = new RestClient($"http://api.openweathermap.org/data/2.5/weather?q={city}&units=metric&APPID={apiKey}");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var content = JsonConvert.DeserializeObject<WeatherResponse>(response.Content);

                return content;
            }

            return null;
        }
    }
}