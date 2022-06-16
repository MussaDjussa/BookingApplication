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
                Caption = " - Пройдите регистрацию, а затем авторизацию",
                Image = "hello.png",
            });Guids.Add(new UserGuide()
            {
                Header = "2. Этап",
                Caption = " - Пройдите регистрацию, а затем авторизацию",
                Image = "hello.png",
            });Guids.Add(new UserGuide()
            {
                Header = "3. Этап",
                Caption = "Пройдите регистрацию, а затем авторизацию",
                Image = "hello.png",
            });Guids.Add(new UserGuide()
            {
                Header = "4. Этап",
                Caption = "Пройдите регистрацию, а затем авторизацию",
                Image = "hello.png",
            });
        }
    }
}