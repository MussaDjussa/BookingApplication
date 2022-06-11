using Syncfusion.SfSchedule.XForms;
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
    public partial class BookingPage : ContentPage
    {

        ScheduleAppointmentCollection scheduleAppointmentCollection = new ScheduleAppointmentCollection();

        public BookingPage()
        {
            InitializeComponent();
            schedule.ScheduleView = ScheduleView.MonthView;
            MonthViewSettings monthViewSettings = new MonthViewSettings();
            monthViewSettings.AgendaViewHeight = 150;
            schedule.MonthViewSettings = monthViewSettings;
            schedule.ShowAppointmentsInline = true;
            schedule.CellTapped += Schedule_CellTapped;

            DayViewSettings dayViewSettings = new DayViewSettings();
            DayLabelSettings dayLabelSettings = new DayLabelSettings();
            dayLabelSettings.TimeFormat = "hh:mm";
            dayViewSettings.DayLabelSettings = dayLabelSettings;
            schedule.DayViewSettings = dayViewSettings;

            WeekViewSettings weekViewSettings = new WeekViewSettings();
            WeekLabelSettings weekLabelSettings = new WeekLabelSettings();
            weekLabelSettings.TimeFormat = "hh:mm";
            weekViewSettings.WeekLabelSettings = weekLabelSettings;
            schedule.WeekViewSettings = weekViewSettings;

            weekLabelSettings.TimeLabelSize = 15;
            weekViewSettings.WeekLabelSettings = weekLabelSettings;
            schedule.WeekViewSettings = weekViewSettings;

            scheduleAppointmentCollection.Add(new ScheduleAppointment()
            {
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddHours(23),
                Subject = "Prikol",
                Location = "ok"
            });

            schedule.DataSource = scheduleAppointmentCollection;
        }
        public DateTime CellTaped { get; set; }
        private void Schedule_CellTapped(object sender, CellTappedEventArgs e)
        {
            CellTaped = e.Datetime;
        }

        private void Day_Clicked(object sender, EventArgs e)
        {
            schedule.ScheduleView = Syncfusion.SfSchedule.XForms.ScheduleView.DayView;
        }

        private void Week_Clicked(object sender, EventArgs e)
        {
            schedule.ScheduleView = Syncfusion.SfSchedule.XForms.ScheduleView.WeekView;
        }

        private void Month_Clicked(object sender, EventArgs e)
        {
            schedule.ScheduleView = Syncfusion.SfSchedule.XForms.ScheduleView.MonthView;
        }

        private void schedule_CellDoubleTapped(object sender, CellTappedEventArgs e)
        {
            //Navigation.ShowPopup(new PopupPage());
        }
    }
}