using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookingApplication
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupFeedbackPage : Popup, INotifyPropertyChanged
    {
        FirebaseClient firebaseClient = new FirebaseClient("https://compclubdb-default-rtdb.europe-west1.firebasedatabase.app/");

        public PopupFeedbackPage()
        {
            InitializeComponent();
            
        }


        private void Button_Clicked(object sender, EventArgs e)
        {
            Dismiss(null);
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            FeedbackModel model = new FeedbackModel() {

                DateTime = DateTime.Now.ToString(),
                FIO = FIO.Text,
                Description = Description.Text,
                FixedFromAdministration = Panishment.Text,
            };

            MyFeedbackPage.feedbackCollection.Add(model);

            firebaseClient.Child("Feedback").PostAsync(new FeedbackModel() { 
            
                DateTime = model.DateTime,
                Description = model.Description,
                FIO = FIO.Text,
                FixedFromAdministration=Panishment.Text,
                UserID = App.ClientModel.ID
            });

            Dismiss(null);
        }
    }
}