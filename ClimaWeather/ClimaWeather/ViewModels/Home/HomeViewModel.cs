using ClimaWeather.DTOs;
using ClimaWeather.ExtensionMethods;
using ClimaWeather.Helpers;
using ClimaWeather.Services.ApiClient;
using ClimaWeather.ViewModels.Base;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ClimaWeather.ViewModels.Home {

    public class HomeViewModel : PulldownViewModel {

        public OnecallDTO Clima { get; set; }
        public string Data { get; set; } = DateTime.Now.ToString("ddd, dd MMM");
        public string Cidade { get; set; }
        public ScrollView SVTemperaturasPorHoraio { get; set; }
        public Button BotaoHoje { get; set; }
        public Button BotaoAmanha { get; set; }

        public HomeViewModel() {
            CarregarAsync();
        }

        public override async Task CarregarAsync() {
            MostrarLoading = true;
            var location = await GPSHelper.GetLocationAsync();
            if (location == null)
                return;


            await new WheatherApi().ObterDadosDoClima(location.Latitude, location.Longitude)
                .ContinueWith(async response => {
                    if (!FoiSucesso(response))
                        await AlertHelper.DisplayAlert("Atenção", "Ocorreu um erro", "Ok");

                    Clima = response.Result.Value;
                });


            await new LocationIQApi().ObterDadosDaGeolocalizacao(location.Latitude, location.Longitude)
                .ContinueWith(async response => {
                    if (!FoiSucesso(response))
                        await AlertHelper.DisplayAlert("Atenção", "Ocorreu um erro", "Ok");

                    Cidade = response.Result.Value.Address.NomeASerExibido;
                });

            VerTemperaturasDeHojeCommand.Execute(null);
            MostrarLoading = false;
        }

        public Command VerTemperaturasDeHojeCommand => new Command( () => {
            VisualStateManager.GoToState(BotaoHoje, "Selected");
            VisualStateManager.GoToState(BotaoAmanha, "Normal");

            SVTemperaturasPorHoraio.ScrollToAsync(0,0,true);
        });

        public Command VerTemperaturasDeAmanhaCommand => new Command(() => {
            var temperaturasDoDia = Clima.Hourly.Select(f => f.Date.UnixTimeStampToDateTime().Hour).ToList();
            var nascerDoSol = Clima.Current.Sunrise.UnixTimeStampToDateTime().Hour;

            var indice = temperaturasDoDia.IndexOf(nascerDoSol);

            VisualStateManager.GoToState(BotaoAmanha, "Selected");
            VisualStateManager.GoToState(BotaoHoje, "Normal");

            SVTemperaturasPorHoraio.ScrollToAsync(73.5 * indice, 0, true);
        });
    }
}