using ClimaWeather.Config;
using ClimaWeather.DTOs;
using ClimaWeather.Services.ApiClient.Base;
using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClimaWeather.Services.ApiClient {
    public class LocationIQApi : BaseApiClient {
        public LocationIQApi() : base(Configuracoes.BaseAddressLocationIQ) {
        }

        protected override string ResourceName => "reverse";

        public async Task<Maybe<ReverseGeolocationDTO>> ObterDadosDaGeolocalizacao(double Latitude, double Longitude) {
            return await RequestGet<ReverseGeolocationDTO>(new { lat = Latitude, lon = Longitude }, "");
        }
    }
}

