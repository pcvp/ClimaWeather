using System;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClimaWeather.Converters {

    public class DataFormatConverter : IValueConverter, IMarkupExtension {
        public string Format { get; set; } = "dd 'de' MMM 'de' yyyy";
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            var valor = value as DateTime?;
            if (valor == null) return null;
            return valor.Value.ToString(Format);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return value;
        }

        public object ProvideValue(IServiceProvider serviceProvider) {
            return this;
        }
    }
}