using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookingApplication
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        public string WebApiKey = "AIzaSyCbwzkqWuxSowj5LweO2VYFrOaktxmB5ek";
        public RegistrationPage()
        {
            InitializeComponent();
            vid.Source = "ms-appx:///prikol.mp4";
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebApiKey));
                var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(UserNewEmail.Text, UserNewPassword.Text);
                string gettoken = auth.FirebaseToken;
                await App.Current.MainPage.DisplayAlert("Уведомление", "Регистрация прошла успешно", "ОК");
            }
            catch 
            {
                await App.Current.MainPage.DisplayAlert("Уведомление", "Введите корректно почту", "OK");
            }
        }
    }
}