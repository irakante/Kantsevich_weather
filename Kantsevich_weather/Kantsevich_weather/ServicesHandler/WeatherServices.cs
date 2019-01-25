using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Kantsevich_weather.Models;
using Kantsevich_weather.WeatherRestClient ;

namespace Kantsevich_weather.ServicesHandler
{
    public class WeatherServices
    {
        OpenWeatherMap<WeatherMainModel> _openWeatherRest = new OpenWeatherMap<WeatherMainModel>();
        public async Task<WeatherMainModel> GetWeatherDetails(string city)
        {
            var getWeatherDetails = await _openWeatherRest.GetAllWeathers(city);
            return getWeatherDetails;
        }
    }
}
