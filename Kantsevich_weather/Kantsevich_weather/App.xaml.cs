using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
 

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Kantsevich_weather
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override   void OnStart()
        {
           //   WeatherMainModel = await _weatherServices.GetWeatherDetails();

        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
