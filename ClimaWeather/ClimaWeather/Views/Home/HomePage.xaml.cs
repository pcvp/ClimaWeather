using ClimaWeather.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClimaWeather.Views.Home {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage {
        public HomePage() {
            InitializeComponent();
            var vm = (HomeViewModel)BindingContext;
            vm.SVTemperaturasPorHoraio = SVTemperaturasPorHorario;
            vm.BotaoHoje = BotaoHoje;
            vm.BotaoAmanha = BotaoAmanha;
        }
    }
}