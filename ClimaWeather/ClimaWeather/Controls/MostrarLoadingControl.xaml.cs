using ClimaWeather.Helpers;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClimaWeather.Controls {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MostrarLoadingControl : StackLayout {

        public MostrarLoadingControl() {
            InitializeComponent();
            IsVisible = Indicator.IsRunning = false;
        }

        
        #region Exibir
        public static readonly BindableProperty ExibirProperty = BindableProperty.Create(
            propertyName: nameof(Exibir),
            returnType: typeof(bool),
            declaringType: typeof(MostrarLoadingControl),
            defaultBindingMode: BindingMode.Default,
            propertyChanged: ((bindable, oldvalue, newValue) => {
                var self = (MostrarLoadingControl)bindable;
                self.IsVisible = self.Indicator.IsRunning = (bool)newValue;
            })
        );


        public bool Exibir {
            get { return (bool)GetValue(ExibirProperty); }
            set { SetValue(ExibirProperty, value); }
        }

        #endregion

    }
}