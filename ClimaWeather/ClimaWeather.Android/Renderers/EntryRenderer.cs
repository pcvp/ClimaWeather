using Android.Content;
using Android.Graphics.Drawables;
using ClimaWeather.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Entry), typeof(BaseEntryRenderer))]

namespace ClimaWeather.Droid.Renderers {

    public class BaseEntryRenderer : EntryRenderer {

        public BaseEntryRenderer(Context context)
            : base(context) {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e) {
            base.OnElementChanged(e);
            if (Control != null) {
                Control.Background = new ColorDrawable(Android.Graphics.Color.Transparent);
            }
        }
    }
}