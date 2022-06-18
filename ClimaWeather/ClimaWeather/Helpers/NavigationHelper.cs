using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ClimaWeather.Helpers {
    public static class NavigationHelper {
        #region Paginas

        public static Task GoToAsync(string rota) {
            var tcs = new TaskCompletionSource<Page>();

            Device.BeginInvokeOnMainThread(async () => {
                try {
                    if (NavegacaoPodeSerFeita(rota))
                        await Shell.Current.GoToAsync(rota);
                    tcs.SetResult(null);
                }
                catch (System.Exception e) {
                    
                    tcs.SetResult(null);
                }
            });

            return tcs.Task;
        }

        public static Task<Page> PopAsync() {
            var tcs = new TaskCompletionSource<Page>();

            Device.BeginInvokeOnMainThread(async () => {
                try {
                    var retorno = await Shell.Current.Navigation.PopAsync();
                    tcs.SetResult(retorno);
                }
                catch (System.Exception e) {
                    
                    tcs.SetResult(null);
                }
            });

            return tcs.Task;
        }

        public static Task PushAsync(Page page) {
            var tcs = new TaskCompletionSource<Page>();

            Device.BeginInvokeOnMainThread(async () => {
                try {
                    if (NavegacaoPodeSerFeita(page.GetType().ToString()))
                        await Shell.Current.Navigation.PushAsync(page);
                    tcs.SetResult(null);
                }
                catch (System.Exception e) {
                    
                    tcs.SetResult(null);
                }
            });

            return tcs.Task;
        }

        #endregion Paginas

        #region Modal

        public static Task PopModalAsync() {
            var tcs = new TaskCompletionSource<Page>();

            Device.BeginInvokeOnMainThread(async () => {
                try {
                    var retorno = await Shell.Current.Navigation.PopModalAsync();
                    tcs.SetResult(retorno);
                }
                catch (System.Exception e) {
                    tcs.SetResult(null);
                }
            });

            return tcs.Task;
        }

        public static Task PushModalAsync(Page page) {
            var tcs = new TaskCompletionSource<Page>();

            Device.BeginInvokeOnMainThread(async () => {
                try {
                    if (NavegacaoPodeSerFeita(page.GetType().ToString()))
                        await Shell.Current.Navigation.PushModalAsync(page);
                    tcs.SetResult(null);
                }
                catch (System.Exception e) {
                    tcs.SetResult(null);
                }
            });

            return tcs.Task;
        }

        #endregion Modal

        #region Popup

        public static Task PopPopupAsync() {
            var tcs = new TaskCompletionSource<Page>();

            Device.BeginInvokeOnMainThread(async () => {
                try {
                    await PopupNavigation.Instance.PopAsync();
                    tcs.SetResult(null);
                }
                catch (System.Exception e) {                    
                    tcs.SetResult(null);
                }
            });

            return tcs.Task;
        }

        public static Task PushPopupAsync(PopupPage page) {
            var tcs = new TaskCompletionSource<Page>();

            Device.BeginInvokeOnMainThread(async () => {
                try {
                    if (NavegacaoPodeSerFeita(page.GetType().ToString()))
                        await PopupNavigation.Instance.PushAsync(page);
                    tcs.SetResult(null);
                }
                catch (System.Exception e) {
                    
                    tcs.SetResult(null);
                }
            });

            return tcs.Task;
        }

        #endregion Popup

        #region NavigationPage
        public static Task NavigationPagePushAsync(Page page) {
            var tcs = new TaskCompletionSource<Page>();

            Device.BeginInvokeOnMainThread(async () => {
                try {
                    await App.Current.MainPage.Navigation.PushAsync(page);
                    tcs.SetResult(null);
                }
                catch (System.Exception e) {
                    
                    tcs.SetResult(null);
                }
            });

            return tcs.Task;
        }
        public static Task<Page> NavigationPagePopAsync() {
            var tcs = new TaskCompletionSource<Page>();

            Device.BeginInvokeOnMainThread(async () => {
                try {
                    var retorno = await Application.Current.MainPage.Navigation.PopAsync();
                    tcs.SetResult(retorno);
                }
                catch (System.Exception e) {
                    
                    tcs.SetResult(null);
                }
            });

            return tcs.Task;
        }

        public static Task NavigationPageGoToAsync(Page page) {
            var tcs = new TaskCompletionSource<Page>();

            Device.BeginInvokeOnMainThread(async () => {
                try {
                    Application.Current.MainPage = new NavigationPage(page);
                    tcs.SetResult(null);
                }
                catch (System.Exception e) {
                    
                    tcs.SetResult(null);
                }
            });

            return tcs.Task;
        }
        #endregion
        
        #region Controle de navagação duplicada
        private static List<string> Hashes { get; } = new List<string>();
        private static DateTime UltimaNavegacao { get; set; }
        private static bool NavegacaoPodeSerFeita(string nome) {
            if ((DateTime.Now - UltimaNavegacao).TotalSeconds > 3)
                Hashes.Clear();
            
            var hash = HashHelper.GetHashString(nome);
            var repetida = Hashes.Contains(hash);
            if (repetida)
                return false;

            Hashes.Add(hash);
            UltimaNavegacao = DateTime.Now;
            return true;
        }
        #endregion
    }
}