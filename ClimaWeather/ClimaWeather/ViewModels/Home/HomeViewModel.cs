using ClimaWeather.Helpers;
using ClimaWeather.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace ClimaWeather.ViewModels.Home {

    public class HomeViewModel : BaseViewModel {

        public HomeViewModel() {
            Carregar();
        }

        public void Carregar() {
            
        }



        public Command RefreshCommand => new Command(() => {
            Carregar();
        });



        public bool IsRefreshing { get; set; }
    }
}