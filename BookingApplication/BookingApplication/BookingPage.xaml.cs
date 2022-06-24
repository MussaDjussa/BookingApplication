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
            Schedule.MinDisplayDate = DateTime.Now;
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

        protected async override void OnAppearing()
        {
            try
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
                    Background = q.Object.Background,
                    UserID = q.Object.UserID,

                });

                foreach (var item in list)
                {
                    App.bookingViewModel.appointmentcollection.Add(new Meeting()
                    {

                        EndRegion = item.EndRegion,
                        StartRegion = item.StartRegion,
                        StartTimeZone = DateTime.Parse(item.StartTimeZone),
                        EndTimeZone = DateTime.Parse(item.EndTimeZone),
                        Note = item.Note,
                        Subject = $"{item.Subject} - {item.TypeRoom}",
                        ColorZone = Color.FromHex(item.Background),
                        UserID = item.UserID,
                        DeviceNumber = item.DeviceNumber,
                        RoomType = item.TypeRoom,
                    });
                }

                await Task.Delay(3000);

                Schedule.DataSource = App.bookingViewModel.appointmentcollection;
                refresher.IsRefreshing = false;
            }
            catch (NullReferenceException)
            {
                await App.Current.MainPage.DisplayAlert("Ошибка", "Что-то пошло не так...", "OK");
            }
        }

        public void SetUp()
        {
            Device.StartTimer(new TimeSpan(0, 10, 0), () => {

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
            try { 
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
                Background = q.Object.Background,
                UserID = q.Object.UserID,
                
            });

            foreach (var item in list)
            {
                App.bookingViewModel.appointmentcollection.Add(new Meeting() {

                    EndRegion = item.EndRegion,
                    StartRegion = item.StartRegion,
                    StartTimeZone = DateTime.Parse(item.StartTimeZone),
                    EndTimeZone = DateTime.Parse(item.EndTimeZone),
                    Note = item.Note,
                    Subject = $"{item.Subject} - {item.TypeRoom}",
                    ColorZone = Color.FromHex(item.Background),
                    UserID = item.UserID,
                    DeviceNumber = item.DeviceNumber,
                    RoomType = item.TypeRoom,
                });
            }
            
            await Task.Delay(3000);

            Schedule.DataSource = App.bookingViewModel.appointmentcollection;
            refresher.IsRefreshing = false;
            }
            catch(NullReferenceException)
            {
                await App.Current.MainPage.DisplayAlert("Ошибка", "Что-то пошло не так...","OK");
                refresher.IsRefreshing = false;
            }
        }

        private void week_Clicked(object sender, EventArgs e)
        {
            Schedule.ScheduleView = ScheduleView.WeekView;
        }

        private void month_Clicked(object sender, EventArgs e)
        {
            Schedule.ScheduleView = ScheduleView.MonthView;
        }

        private void Schedule_CellLongPressed(object sender, CellTappedEventArgs e)
        {
            
                Navigation.ShowPopup(new PopupBookingList(MeetingTemp));
         
           
        }

        public List<Meeting> MeetingTemp { get; set; } = new List<Meeting>(); 
        private void Schedule_CellTapped(object sender, CellTappedEventArgs e)
        {
            if(e.Appointments != null)
            {
                MeetingTemp.Clear();
                foreach (var outter in e.Appointments)
                {
                    
                        MeetingTemp.Add((Meeting)outter);
                }
                
            }
            
        }
    }
}