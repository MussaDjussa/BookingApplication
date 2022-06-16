﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookingApplication
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PreviewPage : ContentPage
    {
        public ObservableCollection<OnBoard> OnBoards { get; set; } = new ObservableCollection<OnBoard>();
        public PreviewPage()
        {
            InitializeComponent();
            Xamarin.Essentials.Permissions.RequestAsync<Xamarin.Essentials.Permissions.StorageRead>();
            vid.Source = "ms-appx:///prikol.mp4";
            BindingContext = this;
            OnBoards.Add(new OnBoard()
            {
                Heading = "Booking - just do it",
                Caption = "now it's easy and convenient"
            });
            OnBoards.Add(new OnBoard()
            {
                Heading = "Booking - just do it",
                Caption = "now it's easy and convenient"
            });
            OnBoards.Add(new OnBoard()
            {
                Heading = "Booking - just do it",
                Caption = "now it's easy and convenient"
            });

            AnimatedCarousel();
        }

        public void AnimatedCarousel()
        {
            Timer timer = new Timer(7000) { AutoReset = true, Enabled = true };

            timer.Elapsed += (s, e) =>
            {

                Device.BeginInvokeOnMainThread(() =>
                {
                    if (carouselView.Position == 2)
                    {
                        carouselView.Position = 0;
                    }

                    carouselView.Position += 1;
                });
            };
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistrationPage());
        }
    }
}