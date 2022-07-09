using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClimaWeather.DTOs.Alert {
    public class AlertDTO {
        [JsonProperty("sender_name")]
        public string SenderName { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("start")]
        public long Start { get; set; }

        [JsonProperty("end")]
        public long End { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("tags")]
        public List<string> Tags { get; set; }
    }
}
