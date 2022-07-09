using ClimaWeather.Helpers;
using CSharpFunctionalExtensions;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ClimaWeather.ViewModels.Base {
    public class BaseViewModel : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        private bool _mostrarLoading;
        public bool MostrarLoading {
            get { return _mostrarLoading; }
            set {
                _mostrarLoading = value;
                App.Current.MainPage.BackgroundColor = value ? ResourceHelper.StaticResourceColor("PrimaryColor") : ResourceHelper.StaticResourceColor("WhiteColor");                
            }
        }

        public virtual Command Voltar => new Command(async () => {
            MostrarLoading = false;
            await NavigationHelper.PopModalAsync();
        });

        public virtual Command VoltarPage => new Command(async () => {
            await NavigationHelper.NavigationPagePopAsync();
        });

        protected bool FoiSucesso<T>(Task<Maybe<T>> response) {
            return !response.IsFaulted && response.Result.HasValue;
        }

        protected bool FoiSucesso<T>(Maybe<T> response) {
            return response.HasValue;
        }
    }
}
