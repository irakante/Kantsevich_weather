using System.ComponentModel;
using System.Runtime.CompilerServices;
using Kantsevich_weather.Models;
using Kantsevich_weather.ServicesHandler;
using System.Threading.Tasks;

namespace Kantsevich_weather.ViewModels
{
    public class WeatherViewModel : INotifyPropertyChanged
    {     
        public WeatherViewModel()
        {
            BackgroundImageDroh = "sun.png";
            Task.Run(async () => {
                await InitializeGetWeatherDrohobychAsync();
            });
        }

        WeatherServices _weatherServices = new WeatherServices();
        private WeatherMainModel _weatherMainModel;  // for xaml binding
        public WeatherMainModel WeatherMainModel
        {
            get { return _weatherMainModel; }
            set
            {
                _weatherMainModel = value;
                IconImageString = "http://openweathermap.org/img/w/" + _weatherMainModel.weather[0].icon + ".png"; // fetch weather icon image
                SetBackgroundImage(_weatherMainModel.weather[0].icon);
                OnPropertyChanged();
            }
        }

       
        private string _city;   // for entry binding and for method parameter value
        public string City
        {
            get { return _city; }
            set
            {
                _city = value;
                Task.Run(async () => {
                    await InitializeGetWeatherAsync();
                });
                OnPropertyChanged();
            }
        }

        private string _backgroundImageDroh; // for weather icon background
        public string BackgroundImageDroh
        {
            get { return _backgroundImageDroh; }
            set
            {
                _backgroundImageDroh = value;
                OnPropertyChanged();
            }
        }

        private string _iconImageString; // for weather icon image string binding
        public string IconImageString
        {
            get { return _iconImageString; }
            set
            {
                _iconImageString = value;
                OnPropertyChanged();
            }
        }

        private bool _isBusy;   // for showing loader when the task is initializing
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }

        private async Task InitializeGetWeatherAsync()
        {
            try
            {
                IsBusy = true; // set the ui property "IsRunning" to true(loading) in Xaml ActivityIndicator Control
                WeatherMainModel = await _weatherServices.GetWeatherDetails(_city);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task InitializeGetWeatherDrohobychAsync()
        {
            try
            {
                IsBusy = true; // set the ui property "IsRunning" to true(loading) in Xaml ActivityIndicator Control
                WeatherMainModel = await _weatherServices.GetWeatherDetailsDrohobych();
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void SetBackgroundImage(string icon)
        {
            if (icon == "01d") { BackgroundImageDroh = "sun.png"; }
            if (icon == "02d") { BackgroundImageDroh = "sun.png"; }
            if (icon == "03d") { BackgroundImageDroh = "drog.png"; }
            if (icon == "04d") { BackgroundImageDroh = "drog.png"; }
            if (icon == "09d") { BackgroundImageDroh = "rain.png"; }
            if (icon == "10d") { BackgroundImageDroh = "rain.png"; }
            if (icon == "11d") { BackgroundImageDroh = "snow.png"; }
            if (icon == "13d") { BackgroundImageDroh = "snow.png"; }
            if (icon == "50d") { BackgroundImageDroh = "drog.png"; }

            if (icon == "01n") { BackgroundImageDroh = "sun.png"; }
            if (icon == "02n") { BackgroundImageDroh = "snow.png"; }
            if (icon == "03n") { BackgroundImageDroh = "drog.png"; }
            if (icon == "04n") { BackgroundImageDroh = "drog.png"; }
            if (icon == "09n") { BackgroundImageDroh = "rain.png"; }
            if (icon == "10n") { BackgroundImageDroh = "rain.png"; }
            if (icon == "11n") { BackgroundImageDroh = "snow.png"; }
            if (icon == "13n") { BackgroundImageDroh = "snow.png"; }
            if (icon == "50n") { BackgroundImageDroh = "drog.png"; }

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }        

    }
}
