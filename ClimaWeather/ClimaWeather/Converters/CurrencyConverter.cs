using System;
using System.Globalization;
using System.Text.RegularExpressions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClimaWeather.Converters {

    public class CurrencyConverter : IValueConverter, IMarkupExtension
    {
        public string Format { get; set; } = "C2";
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            var valor = value as decimal?;

            return valor?.ToString(Format);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            var valorFormatado = (string)value;
            var somenteNumeros = Regex.Replace(valorFormatado, @"\D", "");

            if (somenteNumeros.Length <= 0)
                return 0m;

            if (!Decimal.TryParse(somenteNumeros, out decimal valor))
                return 0m;

            return valor / 100m;
        }

        public object ProvideValue(IServiceProvider serviceProvider) {
            return this;
        }
    }
}