﻿using ClimaWeather;
using ClimaWeather.Config;
using ClimaWeather.Factories;
using ClimaWeather.Helpers;
using Flurl.Http;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ClimaWeather {
    public partial class App : Application {

        public App() {
            InitializeComponent();

            var culture = new System.Globalization.CultureInfo(Configuracoes.CultureInfoName);
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;


            FlurlHttp.Configure(c => {
                //c.DefaultTimeout = TimeSpan.FromMinutes(10);
                c.Timeout = TimeSpan.FromMinutes(10);
                c.BeforeCallAsync = AntesDeTodasAsRequisicoesHttp;
                //c.OnErrorAsync = ErroEmConexoes;
                c.HttpClientFactory = new PollyHttpClientFactory();
            });


            MainPage = new AppShell();

        }

        protected override void OnStart() {
        }

        protected override void OnSleep() {
        }

        protected override void OnResume() {
        }

        private async Task AntesDeTodasAsRequisicoesHttp(FlurlCall call) {
            call.Request.SetQueryParam("appid", Configuracoes.ApiKey);
            Console.WriteLine($"[APP] Requisição [{call.Request.Verb}] {call.Request.Url}");
        }
    }
}
