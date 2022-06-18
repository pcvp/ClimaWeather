using System;
using System.ComponentModel;
using System.Windows.Input;
using ClimaWeather.Helpers;
using ClimaWeather.Utils;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClimaWeather.Controls {

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DatePickerControl : StackLayout {

        public DatePickerControl() {
            InitializeComponent();


            Date = null;
            DatePicker.BindingContext = this;
            this.DatePicker.SetBinding(DatePicker.DateProperty, nameof(Date));
            InputControl.IconeCommand = IconeCommand;
        }

        #region NomeDoCampo

        public static readonly BindableProperty NomeDoCampoProperty = BindableProperty.Create(
          propertyName: "NomeDoCampo",
          returnType: typeof(string),
          declaringType: typeof(DatePickerControl),
          defaultBindingMode: BindingMode.Default,
          propertyChanged: ((bindable, oldvalue, newValue) => {
              var self = (DatePickerControl)bindable;
              self.InputControl.NomeDoCampo = newValue.ToString();
          })
        );

        public string NomeDoCampo {
            get { return (string)GetValue(NomeDoCampoProperty); }
            set { SetValue(NomeDoCampoProperty, value); }
        }

        #endregion NomeDoCampo

        #region Date

        public static readonly BindableProperty DateProperty = BindableProperty.Create(
           propertyName: nameof(Date),
           returnType: typeof(DateTime?),
           declaringType: typeof(DatePickerControl),
           defaultBindingMode: BindingMode.TwoWay,
           propertyChanged: ((bindable, oldvalue, newValue) => {
               if (newValue == null)
                   return;

               var self = (DatePickerControl)bindable;
               if (newValue != null) { 
                   self.DatePicker.Date = (DateTime)newValue;
                   self.InputControl.Valor = ((DateTime)newValue).ToString("dd/MM/yyyy");
               }
           })
       );

        public DateTime? Date {
            get { return (DateTime?)GetValue(DateProperty); }
            set { SetValue(DateProperty, value); }
        }

        #endregion Date

        #region MensagemDeErro

        public static readonly BindableProperty MensagemDeErroProperty = BindableProperty.Create(
           propertyName: nameof(MensagemDeErro),
           returnType: typeof(string),
           declaringType: typeof(DatePickerControl),
           defaultBindingMode: BindingMode.TwoWay,
           propertyChanged: ((bindable, oldvalue, newValue) => {
               var self = (DatePickerControl)bindable;
               self.InputControl.MensagemDeErro = string.Empty;
               if (newValue != null && newValue is string) {
                   self.InputControl.MensagemDeErro = newValue.ToString();
               }

           })
       );

        public string MensagemDeErro {
            get { return (string)GetValue(MensagemDeErroProperty); }
            set { SetValue(MensagemDeErroProperty, value); }
        }

        #endregion MensagemDeErro

        #region Obrigatorio

        public static readonly BindableProperty ObrigatorioProperty = BindableProperty.Create(
           propertyName: nameof(Obrigatorio),
           returnType: typeof(bool),
           declaringType: typeof(DatePickerControl),
           defaultBindingMode: BindingMode.Default,
           propertyChanged: ((bindable, oldvalue, newValue) => {
               var self = (DatePickerControl)bindable;
               self.InputControl.Obrigatorio = (bool)newValue;
           })
       );

        public bool Obrigatorio {
            get { return (bool)GetValue(ObrigatorioProperty); }
            set { SetValue(ObrigatorioProperty, value); }
        }

        #endregion Obrigatorio

        public Command IconeCommand => new Command(() => {
            DatePicker.Focus();
        });
        private void InputControl_TextChangedEvent(object sender, EventArgs e) {
            Debounce debounce = new Debounce();
            debounce.Execute(() => {
                Device.BeginInvokeOnMainThread(() => {
                    AdicionarBarraNaData();
                });
            }, 500);
        }

        private void AdicionarBarraNaData() {
            if (InputControl.Valor.Length > 2 && InputControl.Valor.Length < 5) {
                var data = InputControl.Valor.Replace("/", "");
                var dia = data.Substring(0, 2);
                var mes = data.Substring(2, data.Length - 2);
                InputControl.Valor = dia + "/" + mes;
            }
            else if (InputControl.Valor.Length > 5 && InputControl.Valor.Length < 10) {
                var data = InputControl.Valor.Replace("/", "");
                var dia = data.Substring(0, 2);
                var mes = data.Substring(2, 2);
                var ano = data.Substring(4, data.Length - 4);
                InputControl.Valor = dia + "/" + mes + "/" + ano;
            }
            else if (InputControl.Valor.Length == 10) {
                DateTime data;
                if (DateTime.TryParse(InputControl.Valor, out data)) {
                    Date = data;
                }
            }
        }
    }
}