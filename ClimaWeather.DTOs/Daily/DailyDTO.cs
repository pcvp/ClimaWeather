using ClimaWeather.DTOs.FeelsLike;
using ClimaWeather.DTOs.Temp;
using ClimaWeather.DTOs.Weather;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ClimaWeather.DTOs.Daily {
    public class DailyDTO {
        [JsonProperty("dt")]
        public long Date { get; set; }

        [JsonProperty("sunrise")]
        public long Sunrise { get; set; }

        [JsonProperty("sunset")]
        public long Sunset { get; set; }

        [JsonProperty("moonrise")]
        public long Moonrise { get; set; }

        [JsonProperty("moonset")]
        public long Moonset { get; set; }

        [JsonProperty("moon_phase")]
        public double MoonPhase { get; set; }

        [JsonProperty("temp")]
        public TempDTO Temp { get; set; }

        [JsonProperty("feels_like")]
        public FeelsLikeDTO FeelsLike { get; set; }

        [JsonProperty("pressure")]
        public int Pressure { get; set; }

        [JsonProperty("humidity")]
        public int Humidity { get; set; }

        [JsonProperty("dew_point")]
        public double DewPoint { get; set; }

        [JsonProperty("wind_speed")]
        public double WindSpeed { get; set; }

        [JsonProperty("wind_deg")]
        public int WindDeg { get; set; }

        [JsonProperty("wind_gust")]
        public double WindGust { get; set; }

        [JsonProperty("weather")]
        public List<WeatherDTO> Weather { get; set; }

        [JsonProperty("clouds")]
        public int Clouds { get; set; }

        [JsonProperty("pop")]
        public double Pop { get; set; }

        [JsonProperty("rain")]
        public double Rain { get; set; }

        [JsonProperty("uvi")]
        public double Uvi { get; set; }
    }
}
