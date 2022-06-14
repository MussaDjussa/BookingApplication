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

namespace BookingApplication
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookingPage : ContentPage
    {
        public BookingPage()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("YOUR LICENSE KEY");
            InitializeComponent();
            Schedule.TimeZone = "Russian Standard Time";
            Schedule.DataSource = scheduleAppointmentCollection;
            SetUp();
        }
        
        public void SetUp()
        {
            Device.StartTimer(new TimeSpan(0, 0, 1), () => {

                Schedule.MinDisplayDate = DateTime.Now;
                Schedule.MaxDisplayDate = DateTime.Now.AddDays(7);
                return true;
            });
        }
        
        private void schedule_CellDoubleTapped(object sender, CellTappedEventArgs e)
        {
            Navigation.ShowPopup(new PopupPage());
        }

        ObservableCollection<Meeting> scheduleAppointmentCollection = new ObservableCollection<Meeting>();
        private void Button_Clicked(object sender, EventArgs e)
        {
            scheduleAppointmentCollection.Add(new Meeting() {
                StartTimeZone = new DateTime(2022, 06, 14, 10, 0, 0),
                EndTimeZone = new DateTime(2022, 06, 14, 12, 0, 0),
                Subject = "Meeting",
                
            });
        }
    }
}