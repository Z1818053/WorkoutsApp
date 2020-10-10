﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Workouts.Services;
using Workouts.Pages;

namespace Workouts
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //It is necessary to load the theme when the app launches. It identifies the last selected/stored theme and based on that, it loads the proper theme resources.
            ThemeManager.LoadTheme();
            DependencyService.Register<MockDataStore>();
            DependencyService.Register<ExerciseStore>();
            MainPage = new NavigationPage(new DashboardPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
