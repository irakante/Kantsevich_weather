using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Kantsevich_weather.WeatherRestClient
{
    public class OpenWeatherMap<T>
    {
        private const string OpenWeatherApi = "http://api.openweathermap.org/data/2.5/weather?";
        private const string Key = "6e55954410667d51646460a24874aad7";
        HttpClient _httpClient = new HttpClient();

        //http://api.openweathermap.org/data/2.5/weather?q=drohobych&units=metric&APPID=653b1f0bf8a08686ac505ef6f05b94c2
        public async Task<T> GetAllWeathers(string city)
        {
            var json = await _httpClient.GetStringAsync(OpenWeatherApi + "q=" + city + "&units=metric&APPID=" + Key);
            var getWeatherModels = JsonConvert.DeserializeObject<T>(json);
            return getWeatherModels;
        }


        //http://api.openweathermap.org/data/2.5/weather?q=drohobych&units=metric&APPID=653b1f0bf8a08686ac505ef6f05b94c2
        public async Task<T> GetAllWeathersDrohobych()
        {
            var json = await _httpClient.GetStringAsync(OpenWeatherApi + "q=drohobych&units=metric&APPID=" + Key);
            var getWeatherModels = JsonConvert.DeserializeObject<T>(json);
            return getWeatherModels;
        }

        //http://api.openweathermap.org/data/2.5/weather?lat=49&lon=23&units=metric&APPID=653b1f0bf8a08686ac505ef6f05b94c2
        public async Task<T> GetWeathersByLocation(Location location)
        {
            var json = await _httpClient.GetStringAsync(OpenWeatherApi + "lat=" + location.Latitude + "&lon="+ location.Longitude + "&units=metric&APPID=" + Key);
            var getWeatherModels = JsonConvert.DeserializeObject<T>(json);
            return getWeatherModels;
        }
    }
}
