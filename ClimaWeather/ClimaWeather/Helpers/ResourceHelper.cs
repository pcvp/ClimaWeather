using System.Linq;
using Xamarin.Forms;

namespace ClimaWeather.Helpers {

    public static class ResourceHelper {

        public static Color StaticResourceColor(string key) => (Color)Application.Current.Resources[key];

        public static Style StaticResourceStyle(string key) => (Style)Application.Current.Resources[key];

        public static string StaticResourceString(string key) {
            var valor = Application.Current.Resources[key];

            return valor is OnPlatform<string>
                ? (string)((OnPlatform<string>)valor).Platforms.FirstOrDefault(p => p.Platform[0] == Device.RuntimePlatform)?.Value
                : (string)valor;
        }
    }
}