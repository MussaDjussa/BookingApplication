using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookingApplication
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();

            timePickerStart.Time = new TimeSpan(DateTime.Now.Hour,DateTime.Now.Minute,DateTime.Now.Second);
            timePickerEnd.Time = new TimeSpan(DateTime.Now.Hour+1, DateTime.Now.Minute, DateTime.Now.Second);

        }


        private void Button_Clicked(object sender, EventArgs e)
        {
            //Dismiss(null);
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {

            //AppointmentModel model = new AppointmentModel()
            //{
            //    EndTime = new TimeSpan(timePickerEnd.Time.Hours, timePickerEnd.Time.Minutes, timePickerEnd.Time.Seconds).ToString(),
            //    StartTime = new TimeSpan(timePickerStart.Time.Hours, timePickerStart.Time.Minutes, timePickerStart.Time.Seconds).ToString(),
            //    TypeRoom = pickerRoom.SelectedItem.ToString(),
            //    Note = comment.Text,
            //    DeviceNumber = deviceNumber.Text,


            //};

            //App.bookingViewModel.appointmentcollection.Add(model);
            //App.bookingViewModel.scheduleAppointmentCollection.Add(new Syncfusion.SfSchedule.XForms.ScheduleAppointment()
            //{

            //    StartTime = DateTime.Parse(model.StartTime),
            //    EndTime = DateTime.Parse(model.EndTime),
            //    StartTimeZone = model.StartTimeZone,
            //    EndTimeZone = model.EndTimeZone,
            //    Notes = model.Note,
            //    Subject = model.Subject,

            //});
        }
    }
}