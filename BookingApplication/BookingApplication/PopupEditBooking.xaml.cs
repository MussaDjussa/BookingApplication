using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Xamarin.CommunityToolkit.UI.Views;

namespace BookingApplication
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupEditBooking : Popup
    {
        public PopupEditBooking(Meeting meeting)
        {
            InitializeComponent();

            timePickerStart.Time = new TimeSpan(meeting.StartTimeZone.Hour, meeting.StartTimeZone.Minute, meeting.StartTimeZone.Second); 
            timePickerEnd.Time = new TimeSpan(meeting.EndTimeZone.Hour, meeting.EndTimeZone.Minute, meeting.EndTimeZone.Second);
            //pickerRoom.SelectedItem = meeting.;
            comment.Text = meeting.Note;
            
        }

        private void timePickerStart_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {

        }

        private void timePickerEnd_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {

        }
    }
}