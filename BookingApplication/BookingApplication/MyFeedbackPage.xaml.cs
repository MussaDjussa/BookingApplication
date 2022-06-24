using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Syncfusion.SfSchedule.XForms;
using Xamarin.CommunityToolkit.Extensions;
using Firebase.Database;
using System.Collections.ObjectModel;

namespace BookingApplication
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyFeedbackPage : ContentPage
    {
        FirebaseClient firebaseClient = new FirebaseClient("https://compclubdb-default-rtdb.europe-west1.firebasedatabase.app/");

        public static ObservableCollection<FeedbackModel> feedbackCollection = new ObservableCollection<FeedbackModel>();

        public MyFeedbackPage()
        {
            InitializeComponent();   
            collection.ItemsSource = feedbackCollection;
            
        }
        public static PopupFeedbackPage popupFeedbackPage = new PopupFeedbackPage();
        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.ShowPopup(popupFeedbackPage);
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

                foreach (var item in list.Where(q=>q.UserID == App.ClientModel.ID))
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

                foreach (var item in list.Where(q => q.UserID == App.ClientModel.ID))
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