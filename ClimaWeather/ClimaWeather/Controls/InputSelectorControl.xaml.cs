using System;
using System.Windows.Input;
using ClimaWeather.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClimaWeather.Controls {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InputSelectorControl : Grid {
        public InputSelectorControl() {
            InitializeComponent();
            Margin = new Thickness(0, 0, 0, 5);
            LabelErro.IsVisible = false;
            LabelCampoObrigatorio.IsVisible = false;
        }

        #region Commands
        public static readonly BindableProperty CommandProperty =
           BindableProperty.Create("Command",
               typeof(Command), typeof(InputSelectorControl), null,
                 propertyChanged: ((bindable, oldvalue, newValue) => {
                     if (newValue == null)
                         return;

                     var self = (InputSelectorControl)bindable;
                     var tapGestureRecognizer = new TapGestureRecognizer();
                     tapGestureRecognizer.Command = (Command)newValue;

                     self.Botao.GestureRecognizers.Add(tapGestureRecognizer); 
                 })
               );

        public Command Command {
            get => (Command)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public static readonly BindableProperty CommandParameterProperty =
            BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(InputSelectorControl), null);

        public object CommandParameter {
            get => (object)GetValue(CommandParameterProperty);
            set => SetValue(CommandParameterProperty, value);
        }        
        #endregion

      
        #region Texto

        public static readonly BindableProperty TextoProperty = BindableProperty.Create(
            propertyName: nameof(Texto),
            returnType: typeof(string),
            declaringType: typeof(InputSelectorControl),
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: ((bindable, oldvalue, newValue) => {                
                var self = (InputSelectorControl)bindable;
                self.LabelTexto.Text = (string)newValue;
            })
        );

        public string Texto {
            get { return (string)GetValue(TextoProperty); }
            set { SetValue(TextoProperty, value); }
        }
        #endregion

        #region NomeDoCampo

        public static readonly BindableProperty NomeDoCampoProperty = BindableProperty.Create(
          propertyName: "NomeDoCampo",
          returnType: typeof(string),
          declaringType: typeof(InputSelectorControl),
          defaultBindingMode: BindingMode.Default,
          propertyChanged: ((bindable, oldvalue, newValue) => {
              var self = (InputSelectorControl)bindable;
              self.LabelNomeDoCampo.Text = newValue.ToString();
              self.LabelContainer.IsVisible = true;
          })
        );

        public string NomeDoCampo {
            get { return (string)GetValue(NomeDoCampoProperty); }
            set { SetValue(NomeDoCampoProperty, value); }
        }

        #endregion NomeDoCampo

        #region Obrigatorio

        public static readonly BindableProperty ObrigatorioProperty = BindableProperty.Create(
           propertyName: nameof(Obrigatorio),
           returnType: typeof(bool),
           declaringType: typeof(InputSelectorControl),
           defaultBindingMode: BindingMode.Default,
           propertyChanged: ((bindable, oldvalue, newValue) => {
               var self = (InputSelectorControl)bindable;
               self.LabelCampoObrigatorio.IsVisible = (bool)newValue;
           })
       );

        public bool Obrigatorio {
            get { return (bool)GetValue(ObrigatorioProperty); }
            set { SetValue(ObrigatorioProperty, value); }
        }

        #endregion Obrigatorio

        #region MensagemDeErro

        public static readonly BindableProperty MensagemDeErroProperty = BindableProperty.Create(
           propertyName: nameof(MensagemDeErro),
           returnType: typeof(string),
           declaringType: typeof(InputSelectorControl),
           defaultBindingMode: BindingMode.Default,
           propertyChanged: ((bindable, oldvalue, newValue) => {
               var self = (InputSelectorControl)bindable;

               if (newValue != null && newValue is string) {
                   self.LabelErro.Text = newValue.ToString();
                   self.LabelErro.IsVisible = !string.IsNullOrWhiteSpace(newValue.ToString());
                   self.Botao.BorderColor = self.LabelErro.IsVisible ? ResourceHelper.StaticResourceColor("RedColor") :
                        ResourceHelper.StaticResourceColor("BorderColor");
               }
           })
       );

        public string MensagemDeErro {
            get { return (string)GetValue(MensagemDeErroProperty); }
            set { SetValue(MensagemDeErroProperty, value); }
        }

        #endregion MensagemDeErro

        
    }
}