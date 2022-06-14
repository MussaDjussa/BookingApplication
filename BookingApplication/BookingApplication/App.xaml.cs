using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BookingApplication.Data;
using System.IO;

namespace BookingApplication
{
    public partial class App : Application
    {
        public static FeedbackViewModel viewModel = new FeedbackViewModel();

        public static BookingViewModel bookingViewModel = new BookingViewModel();

        static UserDB userDB;

        public static UserDB UserDB
        {
            get
            {
                if(userDB == null)
                {
                    userDB = new UserDB(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"UserDB.db3"));

                }
                return userDB;
            }
        }

        public App()
        {

            InitializeComponent();

            //MainPage = new AppShell();
            //MainPage = new MainPage();
            MainPage = new BookingPage();
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
