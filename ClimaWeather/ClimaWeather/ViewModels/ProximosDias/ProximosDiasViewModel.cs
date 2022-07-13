using ClimaWeather.DTOs;
using ClimaWeather.DTOs.Daily;
using ClimaWeather.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClimaWeather.ViewModels.ProximosDias {
    public class ProximosDiasViewModel {
        public OnecallDTO Clima { get; private set; }
        public DailyDTO ClimaAmanha { get; set; }
        public string TextoQuantidadeDeChuvaAmanha { get; private set; }
        public string TextoVentoAmanha { get; private set; }         
        public string TextoHumidadeAmanha { get; private set; }

        public void CarregarDados(OnecallDTO clima) {
            Clima = clima;
            ClimaAmanha = Clima?.Daily?
            .FirstOrDefault(f => f.Date.UnixTimeStampToDateTime().Date == DateTime.Now.AddDays(1).Date);

            TextoHumidadeAmanha = string.Concat(ClimaAmanha?.Humidity.ToString() ?? "0", "%");
            TextoVentoAmanha = string.Concat(ClimaAmanha?.WindSpeed.ToString() ?? "0", " km/h");
            TextoQuantidadeDeChuvaAmanha = string.Concat(ClimaAmanha?.Rain.ToString() ?? "0", "mm");
        }



    }
}
