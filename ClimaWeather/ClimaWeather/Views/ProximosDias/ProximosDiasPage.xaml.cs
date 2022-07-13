using ClimaWeather.DTOs;
using ClimaWeather.ViewModels.ProximosDias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClimaWeather.Views.ProximosDias {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProximosDiasPage : ContentPage {
        public ProximosDiasPage(OnecallDTO clima) {
            InitializeComponent();
            var vm = (ProximosDiasViewModel)BindingContext;
            vm.CarregarDados(clima);
        }
    }
}