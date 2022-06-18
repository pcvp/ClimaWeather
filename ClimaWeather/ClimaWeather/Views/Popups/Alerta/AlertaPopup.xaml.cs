using ClimaWeather.Helpers;
using ClimaWeather.Views.Shared.Events;
using Rg.Plugins.Popup.Pages;
using System;
using Xamarin.Forms.Xaml;

namespace ClimaWeather.Views.Popups.Alerta {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlertaPopup : PopupPage {
        public event EventHandler OnRespostaSelecionada;
        public AlertaPopup(string titulo, string mensagem, string botaoNao, string botaoSim = "") {
            InitializeComponent();
            Titulo.Text = titulo;
            Mensagem.Text = mensagem;
            BotaoNao.Text = botaoNao;


            BotaoSim.Text = botaoSim;
            BotaoSim.IsVisible = !string.IsNullOrEmpty(botaoSim);

            if (!BotaoSim.IsVisible)
                BotaoNao.Style = ResourceHelper.StaticResourceStyle("RaisedPrimary");
        }

        private void BotaoNao_Clicked(object sender, System.EventArgs e) {
            OnRespostaSelecionada?.Invoke(this, new ItemSelecionadoEventArgs(false));
        }

        private void BotaoSim_Clicked(object sender, System.EventArgs e) {
            OnRespostaSelecionada?.Invoke(this, new ItemSelecionadoEventArgs(true));
        }
    }
}