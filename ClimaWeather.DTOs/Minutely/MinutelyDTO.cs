using Newtonsoft.Json;

namespace ClimaWeather.DTOs.Minutely {
    public class MinutelyDTO {
        [JsonProperty("dt")]
        public long Date { get; set; }

        [JsonProperty("precipitation")]
        public int Precipitation { get; set; }
    }
}
