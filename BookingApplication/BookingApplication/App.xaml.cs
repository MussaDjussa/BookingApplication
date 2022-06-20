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

        public static PageStateViewModel StateViewModel = new PageStateViewModel();
        public static ClientModel ClientModel = new ClientModel();

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
        public static AppShell appShell = new AppShell();
        public App()
        {
            MainPage = new MainPage();
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
