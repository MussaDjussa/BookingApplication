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
using BookingApplication.Helpers;

namespace BookingApplication
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public ObservableCollection<UserGuide> Guids { get; set; } = new ObservableCollection<UserGuide>();
        public Page1()
        {
            InitializeComponent();
            BindingContext = this;
            vid.Source = "ms-appx:///prikol.mp4";
            carouselView.ItemsSource = Guids;
            Guids.Add(new UserGuide()
            {
                Header = "1. Этап",
                Caption = " - Пройдите регистрацию, а затем пройдите авторизацию",
                Image = "preauth.png",
            });Guids.Add(new UserGuide()
            {
                Header = "2. Этап",
                Caption = " - После успешной регистрации, откроется главное окно, где потребуется свайпнуть слева, чтобы открыть выдвигающееся меню",
                Image = "swipeprevi.png",
            });Guids.Add(new UserGuide()
            {
                Header = "3. Этап",
                Caption = "Выберите желаемый день бронирования, сделав двойное касание. После чего выберите время и место.",
                Image = "bookingprev.png",
            });
        }

        private void carouselView_CurrentItemChanged(object sender, CurrentItemChangedEventArgs e)
        {
            if(carouselView.Position == 2)
            {
                startBtn.IsVisible = true;
            }
            else
            {
                startBtn.IsVisible = false;
            }
        }

        private async void startBtn_Clicked(object sender, EventArgs e)
        {
            Settings.LastPreviewState = "true";

            var route = $"{nameof(PreviewPage)}";
            await Shell.Current.GoToAsync(route);
        }

        protected async override void OnAppearing()
        {
            if (Settings.LastPreviewState == "false")
            {
                var route = $"{nameof(PreviewPage)}";
                await Shell.Current.GoToAsync(route);
            }
        }
    }
}