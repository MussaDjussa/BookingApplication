using Syncfusion.SfSchedule.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.CommunityToolkit.Extensions;

namespace BookingApplication
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookingPage : ContentPage
    {

        ScheduleAppointmentCollection scheduleAppointmentCollection = new ScheduleAppointmentCollection();

        public BookingPage()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("YOUR LICENSE KEY");
            InitializeComponent();
           
           
        }
        
        private void schedule_CellDoubleTapped(object sender, CellTappedEventArgs e)
        {
            Navigation.ShowPopup(new PopupPage());
        }
    }
}