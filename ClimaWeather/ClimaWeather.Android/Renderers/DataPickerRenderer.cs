using Android.Content;
using Android.Graphics.Drawables;
using ClimaWeather.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(DatePicker), typeof(BaseDatePickerRenderer))]

namespace ClimaWeather.Droid.Renderers {

    public class BaseDatePickerRenderer : DatePickerRenderer {

        public BaseDatePickerRenderer(Context context)
            : base(context) {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e) {
            base.OnElementChanged(e);
            if (Control != null) {
                Control.Background = new ColorDrawable(Android.Graphics.Color.Transparent);
            }
        }
    }
}