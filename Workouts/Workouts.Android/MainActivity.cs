﻿using Android.App;
using Android.Content.PM;
using Android.OS;
using ImageCircle.Forms.Plugin.Droid;

namespace Workouts.Droid
{
    [Activity(Label = "Workouts", Icon = "@drawable/icon", Theme = "@style/lightAppTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        //Used to get the Toolbar and then themify the Toolbar icons from this
        public static MainActivity Instance = null;

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            //Set Native Android theme as per the Current Theme selection.
            var theme = ThemeManager.CurrentTheme();
            switch (theme)
            {
                case Themes.Light:
                    {
                        SetTheme(Resource.Style.lightAppTheme);
                        break;
                    }
                case Themes.Dark:
                    {
                        SetTheme(Resource.Style.darkAppTheme);
                        break;
                    }
                case Themes.Blue:
                    {
                        SetTheme(Resource.Style.blueAppTheme);
                        break;
                    }
                case Themes.Orange:
                    {
                        SetTheme(Resource.Style.orangeAppTheme);
                        break;
                    }
                case Themes.White:
                    {
                        SetTheme(Resource.Style.whiteAppTheme);
                        break;
                    }
                default:
                    SetTheme(Resource.Style.lightAppTheme);
                    break;
            }

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            ImageCircleRenderer.Init();
            LoadApplication(new App());
            Instance = this;
        }
    }
}

