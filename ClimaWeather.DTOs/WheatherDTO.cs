using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ClimaWeather.DTOs {
    public class WheatherDTO {
        [JsonProperty("coord")]
        public CoordenadasDTO Coordenadas { get; set; }

        [JsonProperty("weather")]
        public List<ClimaDTO> Clima { get; set; }

        [JsonProperty("base")]
        public string Base { get; set; }

        [JsonProperty("main")]
        public DadosPrincipaisDTO DadosPrincipais { get; set; }

        [JsonProperty("visibility")]
        public int Visibilidade { get; set; }

        [JsonProperty("wind")]
        public VentoDTO Vento { get; set; }

        [JsonProperty("clouds")]
        public NuvensDTO Nuvens { get; set; }

        [JsonProperty("name")]
        public string NomeDaCidade { get; set; }
    }

    public class CoordenadasDTO {
        [JsonProperty("lon")]
        public double Longitude { get; set; }
        [JsonProperty("lat")]
        public double Latitude { get; set; }
    }

    public class ClimaDTO {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("main")]
        public string Main { get; set; }

        [JsonProperty("description")]
        public string Descricao { get; set; }

        [JsonProperty("icon")]
        public string Icone { get; set; }
    }

    public class DadosPrincipaisDTO {
        [JsonProperty("temp")]
        public double Temperatura { get; set; }

        [JsonProperty("feels_like")]
        public double SensacaoTermica { get; set; }

        [JsonProperty("temp_min")]
        public double TemperaturaMinima { get; set; }

        [JsonProperty("temp_max")]
        public double TemperaturaMaxima { get; set; }

        [JsonProperty("pressure")]
        public int Pressao { get; set; }

        [JsonProperty("humidity")]
        public int Humidade { get; set; }

        [JsonProperty("sea_level")]
        public int NivelDoMar { get; set; }

        [JsonProperty("grnd_level")]
        public int NivelDoChao { get; set; }
    }

    public class VentoDTO {
        [JsonProperty("speed")]
        public double Velocidade { get; set; }

        [JsonProperty("deg")]
        public double Direcao { get; set; }

        [JsonProperty("gust")]
        public double RajadaDeVento { get; set; }
    } 

    public class NuvensDTO {
        [JsonProperty("all")]
        public int Porcentagem { get; set; }
    }

    public class Chuva {
        [JsonProperty("1h")]
        public int VolumeDeChuvaUltimaHora { get; set; }
        [JsonProperty("3h")]
        public int VolumeDeChuvaUltimasTresHoras { get; set; }
    }
}
