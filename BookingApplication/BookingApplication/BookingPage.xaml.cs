using Syncfusion.SfSchedule.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.CommunityToolkit.Extensions;
using System.Collections.ObjectModel;
using Firebase.Database.Query;
using Firebase.Database;

namespace BookingApplication
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookingPage : ContentPage
    {
        FirebaseClient firebaseClient = new FirebaseClient("https://compclubdb-default-rtdb.europe-west1.firebasedatabase.app/");

        public BookingPage()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("YOUR LICENSE KEY");
            InitializeComponent();
            Schedule.TimeZone = "Russian Standard Time";
            SetUp();

            var collection = firebaseClient
                .Child("Booking")
                .AsObservable<Meeting>()
                .Subscribe((dbevent) =>
                {
                    if(dbevent.Object != null)
                    {
                        App.bookingViewModel.appointmentcollection.Add(dbevent.Object);
                    }
                });

            Schedule.DataSource = App.bookingViewModel.appointmentcollection;
        }
        
        public void SetUp()
        {
            Device.StartTimer(new TimeSpan(0, 0, 1), () => {

                Schedule.MinDisplayDate = DateTime.Now;
                Schedule.MaxDisplayDate = DateTime.Now.AddDays(14);
                return true;
            });
        }
        
        private void schedule_CellDoubleTapped(object sender, CellTappedEventArgs e)
        {
            Navigation.ShowPopup(new PopupPage(e.Datetime));
        }
     
      
        private async void RefreshView_Refreshing(object sender, EventArgs e)
        {
            App.bookingViewModel.appointmentcollection.Clear();

            var list = (await firebaseClient.Child("Booking").OnceAsync<Booking>()).Select(q => new Booking
            {
                DeviceNumber = q.Object.DeviceNumber,
                EndRegion = q.Object.EndRegion,
                StartRegion = q.Object.StartRegion,
                EndTimeZone = q.Object.EndTimeZone,
                Note = q.Object.Note,
                StartTimeZone = q.Object.StartTimeZone,
                Subject = q.Object.Subject,
                TypeRoom = q.Object.TypeRoom,

            });

            foreach (var item in list)
            {
                App.bookingViewModel.appointmentcollection.Add(new Meeting() {

                    //DeviceNumber = item.DeviceNumber,
                    EndRegion = item.EndRegion,
                    StartRegion = item.StartRegion,
                    StartTimeZone = DateTime.Parse(item.StartTimeZone),
                    EndTimeZone = DateTime.Parse(item.EndTimeZone),
                    Note = item.Note,
                    Subject = item.Subject,
                    //TypeRoom = item.TypeRoom,
                });
            }
            Schedule.DataSource = App.bookingViewModel.appointmentcollection;
            await Task.Delay(3000);
            refresher.IsRefreshing = false;

        }
    }
}