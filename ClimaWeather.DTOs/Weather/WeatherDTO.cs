using Newtonsoft.Json;

namespace ClimaWeather.DTOs.Weather {
    public class WeatherDTO {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("main")]
        public string Main { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        public string IconURL => string.Concat("http://openweathermap.org/img/wn/", Icon, "@2x.png");
    }
}
