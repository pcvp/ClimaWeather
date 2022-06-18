using ClimaWeather.Views.Popups.Alerta;
using ClimaWeather.Views.Shared.Events;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ClimaWeather.Helpers
{
    public static class AlertHelper
    {
        private static bool existeAlertaSendoExibido;

        public static async Task<bool> DisplayAlert(string title, string message, string cancel = "Ok")
        {
            var tcs = new TaskCompletionSource<bool>();
            title = string.IsNullOrEmpty(title) ? "Atenção!" : title;

            var page = new AlertaPopup(title, message, cancel);

            page.OnRespostaSelecionada += (sender, args) =>
            {
                try
                {
                    tcs.SetResult(false);
                    NavigationHelper.PopPopupAsync();
                }
                catch (Exception)
                {
                }
                existeAlertaSendoExibido = false;
            };

            existeAlertaSendoExibido = true;
            await NavigationHelper.PushPopupAsync(page);

            return await tcs.Task;
        }

        public static async Task<bool> DisplayAlert(string title, string message, string accept, string cancel)
        {
            var tcs = new TaskCompletionSource<bool>();
            title = string.IsNullOrEmpty(title) ? "Atenção!" : title;

            var page = new AlertaPopup(title, message, cancel, accept);

            page.OnRespostaSelecionada += (sender, args) =>
            {
                tcs.SetResult(Convert.ToBoolean(((ItemSelecionadoEventArgs)args).ItemSelecionado));
                existeAlertaSendoExibido = false;
                NavigationHelper.PopPopupAsync();
            };
            existeAlertaSendoExibido = true;
            await NavigationHelper.PushPopupAsync(page);

            return await tcs.Task;
        }

        public static bool ExisteAlertaSendoExibido()
        {
            return existeAlertaSendoExibido;
        }
    }
}