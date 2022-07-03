using Newtonsoft.Json;

namespace ClimaWeather.DTOs.FeelsLike {
    public class FeelsLikeDTO {
        [JsonProperty("day")]
        public double Day { get; set; }

        [JsonProperty("night")]
        public double Night { get; set; }

        [JsonProperty("eve")]
        public double Eve { get; set; }

        [JsonProperty("morn")]
        public double Morn { get; set; }
    }
}
