using System;

namespace ClimaWeather.ExtensionMethods {
    public static class DateExtension {
        public static DateTime UnixTimeStampToDateTime(this long unixTimeStamp) {
            // Unix timestamp is seconds past epoch
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }
    }
}
