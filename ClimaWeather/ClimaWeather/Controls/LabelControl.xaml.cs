using System;
using System.ComponentModel;
using System.Windows.Input;
using ClimaWeather.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClimaWeather.Controls {

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LabelControl : StackLayout {

        public LabelControl() {
            InitializeComponent();
        }

        #region NomeDoCampo

        public static readonly BindableProperty NomeDoCampoProperty = BindableProperty.Create(
          propertyName: "NomeDoCampo",
          returnType: typeof(string),
          declaringType: typeof(LabelControl),
          defaultBindingMode: BindingMode.Default,
          propertyChanged: ((bindable, oldvalue, newValue) => {
              var self = (LabelControl)bindable;
              self.LabelNomeDoCampo.Text = newValue.ToString();
          })
        );

        public string NomeDoCampo {
            get { return (string)GetValue(NomeDoCampoProperty); }
            set { SetValue(NomeDoCampoProperty, value); }
        }

        #endregion NomeDoCampo

        #region Valor

        public static readonly BindableProperty ValorProperty = BindableProperty.Create(
           propertyName: nameof(Valor),
           returnType: typeof(string),
           declaringType: typeof(LabelControl),
           defaultBindingMode: BindingMode.TwoWay,
           propertyChanged: ((bindable, oldvalue, newValue) => {
               if (newValue == null)
                   return;

               var self = (LabelControl)bindable;               
               self.LabelTexto.Text = (string)newValue;               
           })
       );

        public string Valor {
            get { return (string)GetValue(ValorProperty); }
            set { SetValue(ValorProperty, value); }
        }

        #endregion Valor       

    }
}