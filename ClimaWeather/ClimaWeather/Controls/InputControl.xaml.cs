using System;
using System.ComponentModel;
using System.Windows.Input;
using ClimaWeather.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClimaWeather.Controls {

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InputControl : Grid {

        public InputControl() {
            InitializeComponent();

            LabelCampoObrigatorio.IsVisible = false;
            LabelErro.IsVisible = false;
            MensagemDeErro = string.Empty;

            LabelContainer.IsVisible = false;
            Entry.BindingContext = this;
            this.Entry.SetBinding(Entry.TextProperty, nameof(Valor));
            Entry.Keyboard = SomenteNumeros ? Keyboard.Numeric : Keyboard.Default;

            ImagemIcone.IsVisible = false;
        }

        #region NomeDoCampo

        public static readonly BindableProperty NomeDoCampoProperty = BindableProperty.Create(
          propertyName: "NomeDoCampo",
          returnType: typeof(string),
          declaringType: typeof(InputControl),
          defaultBindingMode: BindingMode.Default,
          propertyChanged: ((bindable, oldvalue, newValue) => {
              var self = (InputControl)bindable;
              self.LabelNomeDoCampo.Text = newValue.ToString();
              self.LabelContainer.IsVisible = true;
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
           declaringType: typeof(InputControl),
           defaultBindingMode: BindingMode.TwoWay,
           propertyChanged: ((bindable, oldvalue, newValue) => {
               if (newValue == null)
                   return;

               var self = (InputControl)bindable;
               if (string.IsNullOrEmpty(newValue.ToString()) && !string.IsNullOrEmpty(self.ValorPadrao))
                   self.Valor = self.ValorPadrao;
               else
                   self.Entry.Text = newValue.ToString();
           })
       );

        public string Valor {
            get { return (string)GetValue(ValorProperty); }
            set { SetValue(ValorProperty, value); }
        }

        #endregion Valor

        #region ValorPadrao

        public static readonly BindableProperty ValorPadraoProperty = BindableProperty.Create(
            propertyName: nameof(ValorPadrao),
            returnType: typeof(string),
            declaringType: typeof(InputControl),
            defaultBindingMode: BindingMode.TwoWay
        );

        public string ValorPadrao {
            get { return (string)GetValue(ValorPadraoProperty); }
            set { SetValue(ValorPadraoProperty, value); }
        }

        #endregion ValorPadrao

        #region Placeholder

        public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(
            propertyName: nameof(Placeholder),
            returnType: typeof(string),
            declaringType: typeof(InputControl),
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: ((bindable, oldvalue, newValue) => {
                if (newValue == null)
                    return;

                var self = (InputControl)bindable;
                self.Entry.Placeholder = newValue.ToString();
            })
        );

        public string Placeholder {
            get { return (string)GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }

        #endregion Placeholder

        #region MensagemDeErro

        public static readonly BindableProperty MensagemDeErroProperty = BindableProperty.Create(
           propertyName: nameof(MensagemDeErro),
           returnType: typeof(string),
           declaringType: typeof(InputControl),
           defaultBindingMode: BindingMode.Default,
           propertyChanged: ((bindable, oldvalue, newValue) => {
               var self = (InputControl)bindable;
               if (newValue != null && newValue is string) {
                   self.LabelErro.Text = newValue.ToString();
                   self.LabelErro.IsVisible = !string.IsNullOrWhiteSpace(newValue.ToString());
                   self.FrameEntry.BorderColor = self.LabelErro.IsVisible ? ResourceHelper.StaticResourceColor("RedColor") :
                        ResourceHelper.StaticResourceColor("BorderColor");
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
           declaringType: typeof(InputControl),
           defaultBindingMode: BindingMode.Default,
           propertyChanged: ((bindable, oldvalue, newValue) => {
               var self = (InputControl)bindable;
               self.LabelCampoObrigatorio.IsVisible = (bool)newValue;
           })
       );

        public bool Obrigatorio {
            get { return (bool)GetValue(ObrigatorioProperty); }
            set { SetValue(ObrigatorioProperty, value); }
        }

        #endregion Obrigatorio

        #region Somente Numeros

        public static readonly BindableProperty SomenteNumerosProperty = BindableProperty.Create(
            propertyName: nameof(SomenteNumeros),
            returnType: typeof(bool),
            declaringType: typeof(InputControl),
            defaultBindingMode: BindingMode.Default,
            propertyChanged: ((bindable, oldvalue, newValue) => {
                var self = (InputControl)bindable;
                self.Entry.Keyboard = (bool)newValue ? Keyboard.Numeric : Keyboard.Default;
            })
        );

        public bool SomenteNumeros {
            get { return (bool)GetValue(SomenteNumerosProperty); }
            set { SetValue(SomenteNumerosProperty, value); }
        }

        #endregion Somente Numeros

        #region Focused
        public static readonly BindableProperty FocusedCommandProperty = BindableProperty.Create(
            propertyName: "FocusedCommand",
            returnType: typeof(ICommand),
            declaringType: typeof(InputControl),
            defaultBindingMode: BindingMode.Default
        );

        public ICommand FocusedCommand {
            get { return (ICommand)GetValue(FocusedCommandProperty); }
            set { SetValue(FocusedCommandProperty, value); }
        }

        private void Entry_OnFocused(object sender, FocusEventArgs e) {
            if (FocusedCommand != null && FocusedCommand.CanExecute(null))
                FocusedCommand.Execute(false);
        }

        #endregion Focused

        #region UnFocused

        public static readonly BindableProperty UnFocusedCommandProperty = BindableProperty.Create(
            propertyName: "UnFocusedCommand",
            returnType: typeof(ICommand),
            declaringType: typeof(InputControl),
            defaultBindingMode: BindingMode.Default
        );

        public ICommand UnFocusedCommand {
            get { return (ICommand)GetValue(UnFocusedCommandProperty); }
            set { SetValue(UnFocusedCommandProperty, value); }
        }

        private void Entry_OnUnfocused(object sender, FocusEventArgs e) {
            if (UnFocusedCommand != null && UnFocusedCommand.CanExecute(null))
                UnFocusedCommand.Execute(false);
            UnFocusedEvent?.Invoke(this, e);
        }

        public event EventHandler<EventArgs> UnFocusedEvent;

        #endregion UnFocused

        #region TextChanged

        public static readonly BindableProperty TextChangedCommandProperty = BindableProperty.Create(
            propertyName: "TextChangedCommand",
            returnType: typeof(ICommand),
            declaringType: typeof(InputControl),
            defaultBindingMode: BindingMode.Default
        );

        public ICommand TextChangedCommand {
            get { return (ICommand)GetValue(TextChangedCommandProperty); }
            set { SetValue(TextChangedCommandProperty, value); }
        }

        private void Entry_OnTextChanged(object sender, TextChangedEventArgs e) {
            if (TextChangedCommand != null && TextChangedCommand.CanExecute(null))
                TextChangedCommand.Execute(false);
            MensagemDeErro = "";
            TextChangedEvent?.Invoke(this, e);
        }

        public event EventHandler<EventArgs> TextChangedEvent;

        #endregion TextChanged     

        #region MaxLenght

        public static readonly BindableProperty MaxLenghtProperty = BindableProperty.Create(
            propertyName: nameof(MaxLenght),
            returnType: typeof(int),
            declaringType: typeof(InputControl),
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: ((bindable, oldvalue, newValue) => {
                var self = (InputControl)bindable;
                self.Entry.MaxLength = (int)newValue;
            })
        );

        public int MaxLenght {
            get { return (int)GetValue(MaxLenghtProperty); }
            set { SetValue(MaxLenghtProperty, value); }
        }

        #endregion MaxLenght

        #region EhSenha
        public static readonly BindableProperty EhSenhaProperty = BindableProperty.Create(
            propertyName: nameof(EhSenha),
            returnType: typeof(bool),
            declaringType: typeof(InputControl),
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: ((bindable, oldvalue, newValue) => {
                var self = (InputControl)bindable;
                self.Entry.IsPassword = (bool)newValue;
            })
        );


        public bool EhSenha {
            get { return (bool)GetValue(EhSenhaProperty); }
            set { SetValue(EhSenhaProperty, value); }
        }
        #endregion

        #region Keyboard
        public static readonly BindableProperty KeyboardProperty = BindableProperty.Create(
            propertyName: nameof(Keyboard),
            returnType: typeof(Keyboard),
            declaringType: typeof(InputControl),
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: ((bindable, oldvalue, newValue) => {
                var self = (InputControl)bindable;
                self.Entry.Keyboard = (Keyboard)newValue;
            })
        );


        public Keyboard Keyboard {
            get { return (Keyboard)GetValue(KeyboardProperty); }
            set { SetValue(KeyboardProperty, value); }
        }
        #endregion

        #region ReturnType
        public static readonly BindableProperty ReturnTypeProperty = BindableProperty.Create(
            propertyName: nameof(ReturnType),
            returnType: typeof(ReturnType),
            declaringType: typeof(InputControl),
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: ((bindable, oldvalue, newValue) => {
                var self = (InputControl)bindable;
                self.Entry.ReturnType = (ReturnType)newValue;
            })
        );


        public ReturnType ReturnType {
            get { return (ReturnType)GetValue(ReturnTypeProperty); }
            set { SetValue(ReturnTypeProperty, value); }
        }
        #endregion

        #region ReturnCommand
        public static readonly BindableProperty ReturnCommandProperty = BindableProperty.Create(
            propertyName: nameof(ReturnCommand),
            returnType: typeof(ICommand),
            declaringType: typeof(InputControl),
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: ((bindable, oldvalue, newValue) => {
                var self = (InputControl)bindable;
                self.Entry.ReturnCommand = (ICommand)newValue;
            })
        );


        public ICommand ReturnCommand {
            get { return (ICommand)GetValue(ReturnCommandProperty); }
            set { SetValue(ReturnCommandProperty, value); }
        }
        #endregion

        #region Alinhamento do Texto
        public BindableProperty _AlinhamentoDoTexto = BindableProperty.Create(
            propertyName: "AlinhamentoDoTexto",
            returnType: typeof(TextAlignment),
            declaringType: typeof(InputControl),
            defaultValue: TextAlignment.Start,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: AlinhamentoPropertyChanged
        );

        private static void AlinhamentoPropertyChanged(BindableObject bindable, object oldvalue, object newvalue) {
            var self = (InputControl)bindable;
            self.Entry.HorizontalTextAlignment = (TextAlignment)newvalue;
        }

        public TextAlignment AlinhamentoDoTexto {
            get { return (TextAlignment)GetValue(_AlinhamentoDoTexto); }
            set { SetValue(_AlinhamentoDoTexto, value); }
        }


        #endregion

        #region Icone

        public static readonly BindableProperty IconeProperty = BindableProperty.Create(
           propertyName: nameof(Icone),
           returnType: typeof(string),
           declaringType: typeof(InputControl),
           defaultBindingMode: BindingMode.Default,
           propertyChanged: ((bindable, oldvalue, newValue) => {
               var self = (InputControl)bindable;

               self.ImagemIcone.Source = newValue.ToString();
               self.ImagemIcone.IsVisible = true;
           })
       );

        public string Icone {
            get { return (string)GetValue(IconeProperty); }
            set { SetValue(IconeProperty, value); }
        }

        #endregion Icone

        #region IconeCommand
        public static readonly BindableProperty IconeCommandProperty = BindableProperty.Create(
            propertyName: nameof(IconeCommand),
            returnType: typeof(ICommand),
            declaringType: typeof(InputControl),
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: ((bindable, oldvalue, newValue) => {
                var self = (InputControl)bindable;
                var tapGesture = new TapGestureRecognizer() {
                    Command = (ICommand)newValue
                };
                self.ImagemIcone.GestureRecognizers.Add(tapGesture);
            })
        );


        public ICommand IconeCommand {
            get { return (ICommand)GetValue(IconeCommandProperty); }
            set { SetValue(IconeCommandProperty, value); }
        }
        #endregion
    }
}