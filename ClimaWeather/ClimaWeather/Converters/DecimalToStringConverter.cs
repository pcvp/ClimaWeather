using System;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClimaWeather.Converters {

    public class DecimalToStringConverter : IValueConverter, IMarkupExtension {
        //https://github.com/xamarin/Xamarin.Forms/issues/7996
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return value == null ? null : ((decimal)value).ToString().Replace(",", ".");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return value;
        }

        public object ProvideValue(IServiceProvider serviceProvider) {
            return this;
        }
    }
}