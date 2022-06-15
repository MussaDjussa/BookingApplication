using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Firebase.Database.Query;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookingApplication
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {

        public ObservableCollection<Booking> Meetings =new ObservableCollection<Booking>();

        FirebaseClient firebaseClient = new FirebaseClient("https://compclubdb-default-rtdb.europe-west1.firebasedatabase.app/");

        public Page1()
        {
            InitializeComponent();
            BindingContext = this;
        }
        public async void GetAllEmployee()
        {

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

            });

            foreach (var item in list)
            {
                Meetings.Add(item);
            }
            

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            GetAllEmployee();

            collection.ItemsSource = Meetings;

        }
    }
}