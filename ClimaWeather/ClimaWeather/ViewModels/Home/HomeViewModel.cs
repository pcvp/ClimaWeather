using ClimaWeather.DTOs;
using ClimaWeather.Helpers;
using ClimaWeather.Services.ApiClient;
using ClimaWeather.ViewModels.Base;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ClimaWeather.ViewModels.Home {

    public class HomeViewModel : BaseViewModel {

        public OnecallDTO Clima { get; set; }
        public string Data { get; set; } = DateTime.Now.ToString("ddd, dd MMM");

        public HomeViewModel() {
            CarregarAsync();
        }

        public async Task CarregarAsync() {
            var location = await GPSHelper.GetLocationAsync();
            if (location == null)
                return;


            await new WheatherApi().ObterDadosDoClima(location.Latitude, location.Longitude)
                .ContinueWith(async response => {
                    if (!FoiSucesso(response))
                        await AlertHelper.DisplayAlert("Atenção", "Ocorreu um erro", "Ok");

                    Clima = response.Result.Value;
                });
            
        }



        public Command RefreshCommand => new Command(async () => {
            await CarregarAsync();
        });



        public bool IsRefreshing { get; set; }
    }
}