using ClimaWeather.Helpers;
using System;
using System.Collections;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClimaWeather.Controls {

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DropdownControl : Grid {

        public DropdownControl() {
            InitializeComponent();

            LabelCampoObrigatorio.IsVisible = StackLayoutNomeDoCampo.IsVisible = false;
            LabelErro.IsVisible = false;

            this.campo.BindingContext = this;
            this.campo.SetBinding(Picker.TitleProperty, nameof(Title));
            this.campo.SetBinding(Picker.ItemsSourceProperty, nameof(ItemsSource));
            this.campo.SetBinding(Picker.SelectedItemProperty, nameof(SelectedItem));

            var clickNoComponente = new TapGestureRecognizer();
            clickNoComponente.Tapped += ClickNoComponente_Tapped;
            campoFakeBackground.BorderColor = ResourceHelper.StaticResourceColor("BorderColor");

            campoFakeBackground.GestureRecognizers.Add(clickNoComponente);
            campo.SelectedIndexChanged += Campo_SelectedIndexChanged;
        }

        private void ClickNoComponente_Tapped(object sender, System.EventArgs e) {
            campo.Focus();
        }

        private void Campo_SelectedIndexChanged(object sender, System.EventArgs e) {
            if (campo.SelectedItem != null)
                campoFake.Text = campo.SelectedItem.ToString();

            MensagemDeErro = "";
            ExibirErro = false;
            CorDaBorda = ResourceHelper.StaticResourceColor("BorderColor");
        }

        public static readonly BindableProperty TitleProperty =
            BindableProperty.Create(nameof(Title), typeof(string), typeof(DropdownControl), null, BindingMode.TwoWay);

        public string Title {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public static readonly BindableProperty ItemDisplayBindingProperty =
            BindableProperty.Create(nameof(ItemDisplayBinding), typeof(BindingBase), typeof(DropdownControl), null, BindingMode.TwoWay,
                propertyChanged: (BindableObject bindable, object oldValue, object newValue) => {
                    var control = (DropdownControl)bindable;

                    control.campo.ItemDisplayBinding = (BindingBase)newValue;
                });

        public BindingBase ItemDisplayBinding {
            get => (BindingBase)GetValue(ItemDisplayBindingProperty);
            set => SetValue(ItemDisplayBindingProperty, value);
        }

        public static readonly BindableProperty ItemsSourceProperty =
            BindableProperty.Create(nameof(ItemsSource), typeof(IList), typeof(DropdownControl), null, BindingMode.TwoWay);

        public IList ItemsSource {
            get => (IList)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        public static new readonly BindableProperty SelectedItemProperty =
            BindableProperty.Create(nameof(SelectedItem), typeof(object), typeof(DropdownControl), null, BindingMode.TwoWay);

        public object SelectedItem {
            get => GetValue(SelectedItemProperty);
            set => SetValue(SelectedItemProperty, value);
        }

        #region CorDaBorda

        public static readonly BindableProperty CorDaBordaProperty = BindableProperty.Create(
            propertyName: nameof(CorDaBorda),
            returnType: typeof(Color),
            declaringType: typeof(DropdownControl),
            defaultBindingMode: BindingMode.Default,
            propertyChanged: ((bindable, oldvalue, newValue) => {
                var self = (DropdownControl)bindable;
                self.campoFakeBackground.BorderColor = (Color)newValue;
            })
        );

        public Color CorDaBorda {
            get { return (Color)GetValue(CorDaBordaProperty); }
            set { SetValue(CorDaBordaProperty, value); }
        }

        #endregion CorDaBorda

        #region MensagemDeErro

        public static readonly BindableProperty MensagemDeErroProperty = BindableProperty.Create(
           propertyName: nameof(MensagemDeErro),
           returnType: typeof(string),
           declaringType: typeof(DropdownControl),
           defaultBindingMode: BindingMode.Default,
           propertyChanged: ((bindable, oldvalue, newValue) => {
               var self = (DropdownControl)bindable;
               if (newValue != null && newValue is string) {
                   self.LabelErro.Text = newValue.ToString();
                   self.LabelErro.IsVisible = !string.IsNullOrWhiteSpace(newValue.ToString());
                   self.campoFakeBackground.BorderColor = self.LabelErro.IsVisible ? ResourceHelper.StaticResourceColor("RedColor") :
                        ResourceHelper.StaticResourceColor("BorderColor");
               }
           })
       );

        public string MensagemDeErro {
            get { return (string)GetValue(MensagemDeErroProperty); }
            set { SetValue(MensagemDeErroProperty, value); }
        }

        #endregion MensagemDeErro

        #region ExibirErro

        public static readonly BindableProperty ExibirErroProperty = BindableProperty.Create(
           propertyName: nameof(ExibirErro),
           returnType: typeof(bool),
           declaringType: typeof(DropdownControl),
           defaultBindingMode: BindingMode.Default,
           propertyChanged: ((bindable, oldvalue, newValue) => {
               var self = (DropdownControl)bindable;
               self.LabelErro.IsVisible = (bool)newValue;
           })
       );

        public bool ExibirErro {
            get { return (bool)GetValue(ExibirErroProperty); }
            set { SetValue(ExibirErroProperty, value); }
        }

        #endregion ExibirErro

        #region NomeDoCampo

        public static readonly BindableProperty NomeDoCampoProperty = BindableProperty.Create(
          propertyName: "NomeDoCampo",
          returnType: typeof(string),
          declaringType: typeof(DropdownControl),
          defaultBindingMode: BindingMode.Default,
          propertyChanged: ((bindable, oldvalue, newValue) => {
              var self = (DropdownControl)bindable;
              self.StackLayoutNomeDoCampo.IsVisible = !string.IsNullOrEmpty(newValue.ToString());
              self.LabelNomeDoCampo.Text = newValue.ToString();
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
           declaringType: typeof(DropdownControl),
           defaultBindingMode: BindingMode.Default,
           propertyChanged: ((bindable, oldvalue, newValue) => {
               var self = (DropdownControl)bindable;
               self.LabelCampoObrigatorio.IsVisible = (bool)newValue;
           })
       );

        public bool Obrigatorio {
            get { return (bool)GetValue(ObrigatorioProperty); }
            set { SetValue(ObrigatorioProperty, value); }
        }

        #endregion Obrigatorio

        #region SelectedIndexChanged

        public event EventHandler<EventArgs> SelectedIndexChanged;

        private void campo_SelectedIndexChanged(object sender, EventArgs e) {
            SelectedIndexChanged?.Invoke(this, e);
        }

        #endregion SelectedIndexChanged
    }
}