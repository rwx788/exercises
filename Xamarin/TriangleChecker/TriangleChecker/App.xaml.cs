﻿using Xamarin.Forms;

namespace TriangleChecker
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new TriangleChecker.MainPage();
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
