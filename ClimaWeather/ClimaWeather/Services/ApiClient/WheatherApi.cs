using ClimaWeather.Config;
using ClimaWeather.DTOs;
using ClimaWeather.Services.ApiClient.Base;
using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClimaWeather.Services.ApiClient {
    public class WheatherApi : BaseApiClient {
        public WheatherApi() : base(Configuracoes.BaseAddress) {
        }

        protected override string ResourceName => "weather";

        public async Task<Maybe<WheatherDTO>> ObterDadosDoClima(double Latitude, double Longitude) {
            return await RequestGet<WheatherDTO>(new { lat = Latitude, lon = Longitude }, "");
        }
    }
}

