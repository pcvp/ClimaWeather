using Xamarin.Forms;

namespace ClimaWeather.Controls {
    public class BorderControl : ContentView {
        /// <summary>
        /// The border color property.
        /// </summary>
        public static readonly BindableProperty BorderColorProperty =
            BindableProperty.Create(
                "BorderColor", typeof(Color), typeof(BorderControl),
            defaultValue: Color.Black);

        /// <summary>
        /// Gets or sets the color of the border.
        /// </summary>
        /// <value>The color of the border.</value>
        public Color BorderColor {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        /// <summary>
        /// The border width property.
        /// </summary>
        public static readonly BindableProperty BorderWidthProperty =
            BindableProperty.Create(
            "BorderWidth", typeof(Thickness), typeof(BorderControl),
            defaultValue: new Thickness(1));

        /// <summary>
        /// Gets or sets the width of the border.
        /// </summary>
        /// <value>The width of the border.</value>
        public Thickness BorderWidth {
            get { return (Thickness)GetValue(BorderWidthProperty); }
            set { SetValue(BorderWidthProperty, value); }
        }

        protected override void OnPropertyChanged(string propertyName = null) {
            base.OnPropertyChanged(propertyName);

            if (nameof(BorderColor).Equals(propertyName)) {
                BackgroundColor = BorderColor;
            }

            if (nameof(BorderWidth).Equals(propertyName)) {
                Padding = BorderWidth;
            }
        }
    }
}
