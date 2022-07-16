using ClimaWeather.DTOs;
using ClimaWeather.DTOs.Daily;
using ClimaWeather.ExtensionMethods;
using ClimaWeather.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClimaWeather.ViewModels.ProximosDias {
    public class ProximosDiasViewModel : BaseViewModel {
        public ProximosDiasViewModel() {
            
        }

        public OnecallDTO Clima { get; private set; }
        public DailyDTO ClimaAmanha => Clima?.Daily?
            .FirstOrDefault(f => f.Date.UnixTimeStampToDateTime().Date == DateTime.Now.AddDays(1).Date);

        public List<DailyDTO> ClimaDosProximosDias => Clima?.Daily?.Where(f => f.Date.UnixTimeStampToDateTime().Date > DateTime.Now.AddDays(1)).ToList();
        public string TextoQuantidadeDeChuvaAmanha => string.Concat(ClimaAmanha?.Rain.ToString() ?? "0", "mm");
        public string TextoVentoAmanha => string.Concat(ClimaAmanha?.WindSpeed.ToString() ?? "0", " km/h");
        public string TextoHumidadeAmanha => string.Concat(ClimaAmanha?.Humidity.ToString() ?? "0", "%");

        public void CarregarDados(OnecallDTO clima) {
            Clima = clima;
        }
    }
}
