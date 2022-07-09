
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ClimaWeather.ViewModels.Base {
    public class PulldownViewModel : BaseViewModel {
        public bool IsRefreshing { get; set; }
        public virtual async Task CarregarAsync() {
            throw new Exception("CarregarAsync não implementado");
        }

        public Command RecarregarCommand => new Command(async () => {
            MostrarLoading = true;
            await CarregarAsync();
            IsRefreshing = false;
        });


    }
}
