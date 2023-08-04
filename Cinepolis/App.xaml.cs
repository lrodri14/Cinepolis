﻿using Cinepolis.Effects;
using Cinepolis.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cinepolis
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new Location());
            
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
