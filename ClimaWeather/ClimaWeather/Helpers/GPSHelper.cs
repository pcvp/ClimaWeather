using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace ClimaWeather.Helpers {
    public static class GPSHelper {
        public static async Task<Location> GetLastKnowLocationAsync() {
            try {
                var location = await Geolocation.GetLastKnownLocationAsync();

                if (location != null) {
                    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                }
                return location;
            } catch (Exception ex) {
                await AlertHelper.DisplayAlert("Erro", ex.Message);
                return null;
            }
        }

        public static async Task<Location> GetLocationAsync() {
            try {
                var location = await Geolocation.GetLocationAsync();

                if (location != null) {
                    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                }
                return location;
            } catch (Exception ex) {
                await AlertHelper.DisplayAlert("Erro", ex.Message);
                return null;
            }
        }
    }
}
