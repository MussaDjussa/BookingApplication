using BookingApplication.Helpers;
using Firebase.Auth;
using Firebase.Database;
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

        FirebaseClient firebaseClient = new FirebaseClient("https://compclubdb-default-rtdb.europe-west1.firebasedatabase.app/");

        public LoginPage()
        {
            InitializeComponent();
            UserLoginEmail.Text = Settings.LastUserEmail;
            UserLoginPassword.Text = Settings.LastUserPassword;
            vid.Source = "ms-appx:///prikol.mp4";
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
           await Navigation.PopAsync();
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


                var value1 = auth.User.LocalId;

                #region code
                //await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
                ;

                Settings.LastUserEmail = UserLoginEmail.Text;
                Settings.LastUserPassword = UserLoginPassword.Text;

                var getRole = (await firebaseClient.Child("Client")
                    .OnceAsync<ClientModel>()).FirstOrDefault(q => q.Object.Email == UserLoginEmail.Text
                    && q.Object.Password == UserLoginPassword.Text);

                App.ClientModel.Password = getRole.Object.Password;
                App.ClientModel.Email = getRole.Object.Email;
                App.ClientModel.RoleType = getRole.Object.RoleType;
                App.ClientModel.UserName = getRole.Object.UserName;
                App.ClientModel.ID = auth.User.LocalId;
                await Shell.Current.GoToAsync($"//{nameof(MainPage)}");

                #endregion

                switch (getRole.Object.RoleType)
                {
                    case "client":
                        await App.Current.MainPage.DisplayAlert("", "Авторизация прошла успешно", "ОК");
                        await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
                        #region setrole
                        App.StateViewModel.ShouldDisplayFlyoutItem_Main = true;
                        App.StateViewModel.ShouldDisplayFlyoutItem_Addition = true;
                        App.StateViewModel.ShouldDisplayFlyoutItem_Booking = true;
                        App.StateViewModel.ShouldDisplayFlyoutItem_FeadBack = true;
                       
                        break;
                    #endregion
                    case "admin":
                        await App.Current.MainPage.DisplayAlert("", "Авторизация прошла успешно", "ОК");
                        await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
                        #region setrole
                        App.StateViewModel.ShouldDisplayFlyoutItem_Main = true;
                        App.StateViewModel.ShouldDisplayFlyoutItem_Addition = false;
                        App.StateViewModel.ShouldDisplayFlyoutItem_Booking = true;
                        App.StateViewModel.ShouldDisplayFlyoutItem_FeadBack = true;
                        break;
                     
                        #endregion
                }


            }
            catch (FirebaseAuthException ex)
            {
                if (ex.Reason == AuthErrorReason.WrongPassword)
                {
                    await App.Current.MainPage.DisplayAlert("Ошибка", "Неверный пароль", "OK");
                }
                if(ex.Reason == AuthErrorReason.UnknownEmailAddress)
                {
                    await App.Current.MainPage.DisplayAlert("Ошибка","Введённый почтовый адресс не зарегистрирован в системе","ОК");
                }
            }
            catch(NullReferenceException ex)
            {
                await App.Current.MainPage.DisplayAlert("Ошибка", "Что-то не так...", "ОК");

            }
        }
    }
}