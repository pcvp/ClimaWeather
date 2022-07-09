using Newtonsoft.Json;

namespace ClimaWeather.DTOs.Rain {
    public class RainDTO {
        [JsonProperty("1h")]
        public int VolumeDeChuvaUltimaHora { get; set; }
        [JsonProperty("3h")]
        public int VolumeDeChuvaUltimasTresHoras { get; set; }
    }
}
