using ClimaWeather.DTOs.Alert;
using ClimaWeather.DTOs.Current;
using ClimaWeather.DTOs.Daily;
using ClimaWeather.DTOs.Hourly;
using ClimaWeather.DTOs.Minutely;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ClimaWeather.DTOs {
    public class OnecallDTO {
        [JsonProperty("lon")]
        public double Lon { get; set; }

        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("timezone_offset")]
        public string TimezoneOffset { get; set; }

        [JsonProperty("current")]
        public CurrentDTO Current { get; set; }

        [JsonProperty("minutely")]
        public List<MinutelyDTO> Minutely { get; set; }

        [JsonProperty("hourly")]
        public List<HourlyDTO> Hourly { get; set; }

        [JsonProperty("daily")]
        public List<DailyDTO> Daily { get; set; }

        [JsonProperty("alerts")]
        public List<AlertDTO> Alerts { get; set; }
    }
}
