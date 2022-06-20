using ClimaWeather.Helpers;
using ClimaWeather.ViewModels.Base;
using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ClimaWeather.ViewModels.Home {

    public class HomeViewModel : BaseViewModel {

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public HomeViewModel() {
            CarregarAsync();
        }

        public async Task CarregarAsync() {
            var location = await GPSHelper.GetLocationAsync();
            if (location == null)
                return;

            Latitude = location.Latitude;
            Longitude = location.Longitude;
        }



        public Command RefreshCommand => new Command(async () => {
            await CarregarAsync();
        });



        public bool IsRefreshing { get; set; }
    }
}