using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Xamarin.CommunityToolkit.UI.Views;
using Firebase.Database;
using Firebase.Database.Query;
using System.Text.RegularExpressions;

namespace BookingApplication
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupEditBooking : Popup
    {
        FirebaseClient firebaseClient = new FirebaseClient("https://compclubdb-default-rtdb.europe-west1.firebasedatabase.app/");

        public Meeting Meeting { get; set; } = new Meeting();
        public PopupEditBooking(Meeting meeting)
        {
            InitializeComponent();
            Meeting.ColorZone = meeting.ColorZone;
            timePickerStart.Time = new TimeSpan(meeting.StartTimeZone.Hour, meeting.StartTimeZone.Minute, meeting.StartTimeZone.Second); 
            timePickerEnd.Time = new TimeSpan(meeting.EndTimeZone.Hour, meeting.EndTimeZone.Minute, meeting.EndTimeZone.Second);
            //pickerRoom.SelectedItem = meeting.;
            comment.Text = meeting.Note;

            if(meeting.RoomType == "вип")
            {
                pickerRoom.SelectedIndex = 0;
            }
            if (meeting.RoomType == "стандарт")
            {
                pickerRoom.SelectedIndex = 1;
            }
            if (meeting.RoomType == "игровая приставка")
            {
                pickerRoom.SelectedIndex = 2;
            }


            deviceNumber.Text = meeting.DeviceNumber;

            Meeting = meeting;
        }

        private void timePickerStart_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {

        }

        private void timePickerEnd_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Dismiss(null);
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            Meeting.Subject = App.ClientModel.UserName;

            Meeting.Note = comment.Text;
            Meeting.EndTimeZone = DateTime.Parse($"{Meeting.EndTimeZone.Year}.{Meeting.EndTimeZone.Month}.{Meeting.EndTimeZone.Day} {timePickerStart.Time.Hours}:{timePickerStart.Time.Minutes}:{timePickerStart.Time.Seconds}"
);          

            Meeting.StartTimeZone = DateTime.Parse($"{Meeting.StartTimeZone.Year}.{Meeting.StartTimeZone.Month}.{Meeting.StartTimeZone.Day} {timePickerEnd.Time.Hours}:{timePickerEnd.Time.Minutes}:{timePickerEnd.Time.Seconds}"
);
            Meeting.RoomType = pickerRoom.SelectedItem.ToString();

            Meeting.DeviceNumber = deviceNumber.Text;

            Meeting.StartRegion = "Russian Standard Time";
            Meeting.EndRegion = "Russian Standard Time";

            MeetingFireBaseModel meetingFireBaseModel = new MeetingFireBaseModel();
            meetingFireBaseModel.Subject = Meeting.Subject;
            meetingFireBaseModel.Note = Meeting.Note;
            meetingFireBaseModel.DeviceNumber = Meeting.DeviceNumber;
            meetingFireBaseModel.TypeRoom = Meeting.RoomType;
            meetingFireBaseModel.StartTimeZone = Meeting.StartTimeZone.ToString();
            meetingFireBaseModel.EndTimeZone = Meeting.EndTimeZone.ToString();
            meetingFireBaseModel.StartRegion = Meeting.StartRegion;
            meetingFireBaseModel.EndRegion = Meeting.EndRegion;
            meetingFireBaseModel.UserID = Meeting.UserID;
            meetingFireBaseModel.Background = Meeting.ColorZone.ToHex();

            /// не нашел
            /// 
             var getModel = (await firebaseClient
                .Child("Booking")
                .OnceAsync<MeetingFireBaseModel>()).FirstOrDefault(q=>q.Object.UserID == Meeting.UserID 
                || q.Object.StartTimeZone == Meeting.StartTimeZone.ToString() || q.Object.EndTimeZone == Meeting.EndTimeZone.ToString()
                || q.Object.DeviceNumber == Meeting.DeviceNumber || q.Object.Note == Meeting.Note);

            await firebaseClient
                .Child("Booking")
                .Child(getModel.Key)
                .PutAsync(meetingFireBaseModel);

            Dismiss(null);

            App.Current.MainPage.DisplayAlert("Успешно","Бронь была изменена!","OK");
        }
    }
}