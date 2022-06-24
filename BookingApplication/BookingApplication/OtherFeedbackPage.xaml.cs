using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookingApplication
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OtherFeedbackPage : ContentPage
    {
        FirebaseClient firebaseClient = new FirebaseClient("https://compclubdb-default-rtdb.europe-west1.firebasedatabase.app/");

        public ObservableCollection<FeedbackModel> feedbackCollection = new ObservableCollection<FeedbackModel>();


        public OtherFeedbackPage()
        {
            InitializeComponent();
           
        }

        private async void refreshView_Refreshing(object sender, EventArgs e)
        {
            try
            {
                feedbackCollection.Clear();

                var list = (await firebaseClient.Child("Feedback").OnceAsync<FeedbackModel>()).Select(q => new FeedbackModel
                {
                    DateTime = q.Object.DateTime,
                    Description = q.Object.Description,
                    FIO = q.Object.FIO,
                    FixedFromAdministration = q.Object.FixedFromAdministration,
                    UserID = q.Object.UserID,
                });

                foreach (var item in list)
                {
                    feedbackCollection.Add(new FeedbackModel()
                    {
                        DateTime = item.DateTime,
                        Description = item.Description,
                        FIO = item.FIO,
                        FixedFromAdministration = item.FixedFromAdministration,
                        UserID = item.UserID,
                    });
                }

                await Task.Delay(1000);

                collection.ItemsSource = feedbackCollection;
                refreshView.IsRefreshing = false;
            }
            catch (NullReferenceException)
            {
                await App.Current.MainPage.DisplayAlert("Ошибка", "Что-то пошло не так...", "OK");
            }
        }


        protected async override void OnAppearing()
        {
            try
            {
                feedbackCollection.Clear();

                var list = (await firebaseClient.Child("Feedback").OnceAsync<FeedbackModel>()).Select(q => new FeedbackModel
                {
                    DateTime = q.Object.DateTime,
                    Description = q.Object.Description,
                    FIO = q.Object.FIO,
                    FixedFromAdministration = q.Object.FixedFromAdministration,
                    UserID = q.Object.UserID,
                });

                foreach (var item in list)
                {
                    feedbackCollection.Add(new FeedbackModel()
                    {
                        DateTime = item.DateTime,
                        Description = item.Description,
                        FIO = item.FIO,
                        FixedFromAdministration = item.FixedFromAdministration,
                        UserID = item.UserID,
                    });
                }

                await Task.Delay(1000);

                collection.ItemsSource = feedbackCollection;
                refreshView.IsRefreshing = false;
            }
            catch (NullReferenceException)
            {
                await App.Current.MainPage.DisplayAlert("Ошибка", "Что-то пошло не так...", "OK");
            }
        }

    }
}