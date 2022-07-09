using ClimaWeather.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClimaWeather.Converters {
    public class GetHourFromUnixTimeConverter : IValueConverter, IMarkupExtension {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            var horario = (long)value;
            var dateTime = horario.UnixTimeStampToDateTime();

            return dateTime.Date == DateTime.Now.Date && dateTime.Hour == DateTime.Now.Hour ? "Agora" : dateTime.ToString("HH:mm");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return value;
        }

        public object ProvideValue(IServiceProvider serviceProvider) {
            return this;
        }
    }
}
