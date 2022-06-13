using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookingApplication
{
    public partial class App : Application
    {
        public static FeedbackViewModel viewModel = new FeedbackViewModel();
        public App()
        {

            InitializeComponent();

            MainPage = new AppShell();
            //MainPage = new MainPage();
            //MainPage = new BookingPage();
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
