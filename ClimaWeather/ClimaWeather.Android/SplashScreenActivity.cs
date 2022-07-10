using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ClimaWeather.Droid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseApp.Droid {
    
    [Activity(Theme = "@style/MainTheme.Splash", Icon = "@mipmap/ic_launcher", MainLauncher = true, NoHistory = true, LaunchMode = LaunchMode.SingleTop)]
    public class SplashScreenActivity : Activity {
        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);

            // Create your application here
            StartActivity(typeof(MainActivity));
        }
    }
}