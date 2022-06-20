using Firebase.Database.Query;
using Syncfusion.SfSchedule.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookingApplication
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupPage : Popup
    {
        public DateTime CellTappedDatTime { get; set; }

        /// <summary>
        /// min date real time ticking...
        /// </summary>
        public string TimeCollapseMinimumDate { get; set; }

        public PopupPage(DateTime cellTapped)
        {
            CellTappedDatTime = cellTapped;

            InitializeComponent();
            SetUp();

            timePickerStart.Time = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            timePickerEnd.Time = new TimeSpan(DateTime.Now.Hour + 1, DateTime.Now.Minute, DateTime.Now.Second);
        }

        public void SetUp()
        {
            Device.StartTimer(new TimeSpan(0, 0, 1), () =>
            {

                TimeCollapseMinimumDate = $"{DateTime.Now.Year}.{DateTime.Now.Month}.{DateTime.Now.Day} {DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}";
                return true;
            });
        }


        private void Button_Clicked(object sender, EventArgs e)
        {
            Dismiss(null);
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            try
            {
                Meeting meeting = new Meeting()
                {
                    StartTimeZone = new DateTime(DateTime.Now.Year, CellTappedDatTime.Month,
                    CellTappedDatTime.Day, timePickerStart.Time.Hours, timePickerStart.Time.Minutes, DateTime.Now.Second),
                    EndTimeZone = new DateTime(DateTime.Now.Year, CellTappedDatTime.Month,
                    CellTappedDatTime.Day, timePickerEnd.Time.Hours, timePickerEnd.Time.Minutes, timePickerEnd.Time.Seconds),
                    Subject = $"{ App.ClientModel.UserName} - {pickerRoom.SelectedItem}" ,
                    StartRegion = "Russian Standard Time",
                    EndRegion = "Russian Standard Time",

                    Note = comment.Text,
                    //ColorZone = Color.FromHex("#d5abeb"),
                };
                if (pickerRoom.SelectedItem == "вип")
                {
                    meeting.ColorZone = Color.FromRgb(255, 111, 33);
                }
                if (pickerRoom.SelectedItem == "стандарт")
                {
                    meeting.ColorZone = Color.FromRgb(122, 255, 33);
                }
                if (pickerRoom.SelectedItem == "игровая приставка")
                {
                    meeting.ColorZone = Color.FromRgb(244, 33, 255);
                }
                await Task.Delay(1500);
                App.bookingViewModel.appointmentcollection.Add(meeting);
                var client = new Firebase.
                    Database.FirebaseClient("https://compclubdb-default-rtdb.europe-west1.firebasedatabase.app/");

                client.Child("Booking").PostAsync(new MeetingFireBaseModel()
                {
                    StartTimeZone = meeting.StartTimeZone.ToString(),
                    EndTimeZone = meeting.EndTimeZone.ToString(),
                    DeviceNumber = deviceNumber.Text,
                    Note = comment.Text,
                    Subject = App.ClientModel.UserName,
                    TypeRoom = pickerRoom.SelectedItem.ToString(),
                    StartRegion = "Russian Standard Time",
                    EndRegion = "Russian Standard Time",
                    Background = $"{meeting.ColorZone.ToHex()}",
                });



                Dismiss(null);
            }
            catch (NullReferenceException)
            {
                await App.Current.MainPage.DisplayAlert("Ошибка", "Что-то пошло не так...", "ОК");
            }


        }

        private void timePickerStart_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (timePickerStart.Time < new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second))
            {
                timePickerStart.Time = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                timePickerEnd.Time = new TimeSpan(timePickerStart.Time.Hours + 1, DateTime.Now.Minute, DateTime.Now.Second);
            }
            else
            {
                timePickerEnd.Time = new TimeSpan(timePickerStart.Time.Hours + 1, timePickerStart.Time.Minutes, DateTime.Now.Second);
            }
        }

        private void timePickerEnd_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (timePickerStart.Time >= timePickerEnd.Time)
            {
                timePickerEnd.Time = new TimeSpan(timePickerStart.Time.Hours + 1, timePickerStart.Time.Minutes, DateTime.Now.Second);
            }
        }
    }
}