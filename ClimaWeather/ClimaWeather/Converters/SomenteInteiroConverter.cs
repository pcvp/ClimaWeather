using System;
using System.Globalization;
using Xamarin.Forms;

namespace ClimaWeather.Converters {

    public class SomenteInteiroConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            var valor = (decimal)value;
            var parteInteira = Math.Truncate(valor);
            return parteInteira.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return value;
        }
    }
}