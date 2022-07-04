using Newtonsoft.Json;

namespace ClimaWeather.DTOs {
    public class ReverseGeolocationDTO {
        [JsonProperty("address")]
        public Address Address { get; set; }
    }

    public class Address {
        [JsonProperty("town")]
        public string Town { get; set; }  
        
        [JsonProperty("suburb")]
        public string Suburb { get; set; }

        public string NomeASerExibido => Suburb ?? Town;
    }
}
