﻿using Firebase.Auth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookingApplication
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public string WebApiKey = "AIzaSyCbwzkqWuxSowj5LweO2VYFrOaktxmB5ek";
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new RegistrationPage());
        }

        private async void loginBtn_Clicked(object sender, EventArgs e)
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebApiKey));
            try
            {
                var auth = await authProvider.SignInWithEmailAndPasswordAsync(UserLoginEmail.Text, UserLoginPassword.Text);
                var content = await auth.GetFreshAuthAsync();
                var serializedcontnet = JsonConvert.SerializeObject(content);
                Preferences.Set("MyFirebaseRefreshToken", serializedcontnet);

                await App.Current.MainPage.DisplayAlert("Уведомление", "Авторизация прошла успешно","ОК");

                await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
                
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("",$"{ex.Message}","ok");
                await App.Current.MainPage.DisplayAlert("Уведомление", "Проверьте правильность ввода логина или пароля", "OK");
            }
        }
    }
}