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
            Schedule.DataSource = App.bookingViewModel.appointmentcollection;
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

            Navigation.ShowPopup(new PopupPage(e.Datetime));
        }

        ObservableCollection<Meeting> scheduleAppointmentCollection = new ObservableCollection<Meeting>();
        private void Button_Clicked(object sender, EventArgs e)
        {
           
        }
    }
}