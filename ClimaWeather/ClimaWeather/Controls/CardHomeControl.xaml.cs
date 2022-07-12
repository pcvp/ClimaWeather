using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClimaWeather.Controls {

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CardHomeControl : FlexLayout {

        public CardHomeControl() {
            InitializeComponent();
            ImagemIcone.IsVisible = false;
        }

        #region Icone

        public static readonly BindableProperty IconeProperty = BindableProperty.Create(
           propertyName: nameof(Icone),
           returnType: typeof(string),
           declaringType: typeof(CardHomeControl),
           defaultBindingMode: BindingMode.Default,
           propertyChanged: ((bindable, oldvalue, newValue) => {
               var self = (CardHomeControl)bindable;


               if (newValue == null)
                   return;


               self.ImagemIcone.Source = newValue.ToString();
               self.ImagemIcone.IsVisible = true;
           })
       );

        public string Icone {
            get { return (string)GetValue(IconeProperty); }
            set { SetValue(IconeProperty, value); }
        }

        #endregion Icone



        #region TextoEsquerda

        public static readonly BindableProperty TextoEsquerdaProperty = BindableProperty.Create(
           propertyName: nameof(TextoEsquerda),
           returnType: typeof(string),
           declaringType: typeof(CardHomeControl),
           defaultBindingMode: BindingMode.Default,
           propertyChanged: ((bindable, oldvalue, newValue) => {
               var self = (CardHomeControl)bindable;
               if (newValue == null)
                   return;

               self.LabelTextoEsquerda.Text = newValue.ToString();
           })
       );

        public string TextoEsquerda {
            get { return (string)GetValue(TextoEsquerdaProperty); }
            set { SetValue(TextoEsquerdaProperty, value); }
        }

        #endregion TextoEsquerda



        #region TextoDireita

        public static readonly BindableProperty TextoDireitaProperty = BindableProperty.Create(
           propertyName: nameof(TextoDireita),
           returnType: typeof(string),
           declaringType: typeof(CardHomeControl),
           defaultBindingMode: BindingMode.Default,
           propertyChanged: ((bindable, oldvalue, newValue) => {
               var self = (CardHomeControl)bindable;
               if (newValue == null)
                   return;

               self.LabelTextoDireita.Text = newValue.ToString();
           })
       );

        public string TextoDireita {
            get { return (string)GetValue(TextoDireitaProperty); }
            set { SetValue(TextoDireitaProperty, value); }
        }

        #endregion TextoDireita
    }
}