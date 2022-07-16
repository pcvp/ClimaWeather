using ClimaWeather.ExtensionMethods;
using System;
using System.Globalization;
using System.Threading;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClimaWeather.Converters {
    public class GetDayFromUnixTimeConverter : IValueConverter, IMarkupExtension {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            var horario = (long)value;
            var dateTime = horario.UnixTimeStampToDateTime();
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            return cultureInfo.TextInfo.ToTitleCase(dateTime.ToString("dddd, dd"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return value;
        }

        public object ProvideValue(IServiceProvider serviceProvider) {
            return this;
        }
    }
}
