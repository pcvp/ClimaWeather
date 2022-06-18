using System;
using System.Globalization;
using Xamarin.Forms;

namespace ClimaWeather.Converters {

    public class HumanizarDataConverter : IValueConverter {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            var valor = value as DateTime?;
            if (valor == null) return null;
            return Humanizar(valor.Value);
        }

        private object Humanizar(DateTime value) {
            var timeShift = DateTime.Now - value;
            int anos = (int)(timeShift.TotalDays / 365);

            if (anos > 0)
                return anos == 1 ? "1 ano atrás" : $"{anos} anos atrás";

            int meses = (int)(timeShift.TotalDays / 30);
            if (meses > 0)
                return meses == 1 ? "1 mês atrás" : $"{meses} meses atrás";

            int dias = (int)timeShift.TotalDays;
            if (dias > 0)
                return dias == 1 ? "1 dia atrás" : $"{dias} dias atrás";

            int horas = (int)timeShift.TotalHours;
            if (horas > 0)
                return horas == 1 ? "1 hora atrás" : $"{horas} horas atrás";

            int minutos = (int)timeShift.TotalMinutes;
            if (minutos > 0)
                return minutos == 1 ? "1 minuto atrás" : $"{minutos} minutos atrás";

            return value.ToShortDateString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return value;
        }
    }
}