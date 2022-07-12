using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClimaWeather.Controls {

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InfoPerHourControl : Frame {

        public InfoPerHourControl() {
            InitializeComponent();
            ImagemIcone.IsVisible = false;
        }

        #region Icone

        public static readonly BindableProperty IconeProperty = BindableProperty.Create(
           propertyName: nameof(Icone),
           returnType: typeof(string),
           declaringType: typeof(InfoPerHourControl),
           defaultBindingMode: BindingMode.Default,
           propertyChanged: ((bindable, oldvalue, newValue) => {
               var self = (InfoPerHourControl)bindable;


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
        
        #region Horario

        public static readonly BindableProperty HorarioProperty = BindableProperty.Create(
           propertyName: nameof(Horario),
           returnType: typeof(string),
           declaringType: typeof(InfoPerHourControl),
           defaultBindingMode: BindingMode.Default,
           propertyChanged: ((bindable, oldvalue, newValue) => {
               var self = (InfoPerHourControl)bindable;


               if (newValue == null)
                   return;


               self.LabelHorario.Text = newValue.ToString();
           })
       );

        public string Horario {
            get { return (string)GetValue(HorarioProperty); }
            set { SetValue(HorarioProperty, value); }
        }

        #endregion Horario

        #region Temperatura

        public static readonly BindableProperty TemperaturaProperty = BindableProperty.Create(
           propertyName: nameof(Temperatura),
           returnType: typeof(string),
           declaringType: typeof(InfoPerHourControl),
           defaultBindingMode: BindingMode.Default,
           propertyChanged: ((bindable, oldvalue, newValue) => {
               var self = (InfoPerHourControl)bindable;
               if (newValue == null)
                   return;

               self.LabelTemperatura.Text = newValue.ToString();
           })
       );

        public string Temperatura {
            get { return (string)GetValue(TemperaturaProperty); }
            set { SetValue(TemperaturaProperty, value); }
        }

        #endregion Temperatura

    }
}