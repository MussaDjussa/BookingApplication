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
        

        public PopupPage()
        {
            InitializeComponent();

            timePickerStart.Time = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            timePickerEnd.Time = new TimeSpan(DateTime.Now.Hour + 1, DateTime.Now.Minute, DateTime.Now.Second);

        }


        private void Button_Clicked(object sender, EventArgs e)
        {
            Dismiss(null);
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            App.bookingViewModel.scheduleAppointmentCollection.Add(new ScheduleAppointment() {
                StartTime = new DateTime(2022, 06, 14, 10, 0, 0),
                EndTime = new DateTime(2022, 06, 14, 12, 0, 0),
                Subject = "Meeting",
                Location = "Hutchison road",
                StartTimeZone = "Russian Standard Time",
                EndTimeZone = "Russian Standart Time",
                
            });
            Dismiss(null);
        }
    }
}