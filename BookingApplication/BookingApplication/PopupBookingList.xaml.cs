using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookingApplication
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupBookingList : Popup
    {
        FirebaseClient firebaseClient = new FirebaseClient("https://compclubdb-default-rtdb.europe-west1.firebasedatabase.app/");
        public ObservableCollection<Meeting> Meeting { get; set; } = new ObservableCollection<Meeting>();
        public PopupBookingList(List<object> list)
        {
            try { 
            InitializeComponent();
            foreach (var item in list)
            {
                Meeting.Add((Meeting)item);
            }

            //for (int i = 0; i < 10; i++)
            //{
            //    Meeting.Add(new Meeting() { ColorZone = Color.LightGray, EndRegion = "Russian Time Standart", StartRegion = "Russian Time Standart", EndTimeZone = DateTime.Now.AddHours(1), StartTimeZone = DateTime.Now, Note = "value", Subject = "Musa - вип" });
            //}
            collection.ItemsSource = Meeting;
            }
            catch(NullReferenceException)
            {

            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                var value = (sender as Button).BindingContext as Meeting;
                var getKey = (await firebaseClient.Child("Booking").OnceAsync<Booking>()).ToList().FirstOrDefault(q => Regex.IsMatch(value.Subject, q.Object.Subject));
                await firebaseClient.Child("Booking").Child(getKey.Key).DeleteAsync();
                App.bookingViewModel.appointmentcollection.Remove(value);
                Meeting.Remove(value);
                collection.ItemsSource = Meeting;

                if (Meeting.Count == 0)
                {
                    Dismiss(null);
                }
            }
            catch (NullReferenceException)
            {

            }
            catch (FirebaseException)
            {

            }
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            var value = (sender as Button).BindingContext as Meeting;
            Navigation.ShowPopup(new PopupEditBooking(value));
        }
    }
}