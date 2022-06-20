using Firebase.Auth;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
                if (string.IsNullOrEmpty(UserNewEmail.Text) && string.IsNullOrEmpty(UserNewPassword.Text) && string.IsNullOrEmpty(UserName.Text))
                {
                    await App.Current.MainPage.DisplayAlert("Ошибка", "Остались пустые поля!", "Понятно");

                }
                else if(UserName.Text.Length <= 1)
                {
                    await App.Current.MainPage.DisplayAlert("Ошибка", "Это недействительное имя!", "Понятно");
                  
                }
                else
                {
                    var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebApiKey));
                    var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(UserNewEmail.Text, UserNewPassword.Text);

                    string gettoken = auth.FirebaseToken;
                    await App.Current.MainPage.DisplayAlert("Уведомление", "Регистрация прошла успешно", "ОК");

                    var clientCreate = new Firebase.
              Database.FirebaseClient("https://compclubdb-default-rtdb.europe-west1.firebasedatabase.app/");
                    clientCreate.Child("Client").PostAsync(new ClientModel()
                    {
                        Email = UserNewEmail.Text,
                        Password = UserNewPassword.Text,
                        UserName = UserName.Text,
                        RoleType = "client"
                    });
                }
            }
            catch (FirebaseAuthException ex)
            {
                if(ex.Reason == AuthErrorReason.EmailExists)
                {
                    await App.Current.MainPage.DisplayAlert("Ошибка", "Адрес электронной почты уже зарегистрирован в системе!", "Понятно");
                }

                if(ex.Reason == AuthErrorReason.WeakPassword)
                {
                    await App.Current.MainPage.DisplayAlert("Ошибка", "Слабый пароль!", "Понятно");
                }
                if(ex.Reason == AuthErrorReason.Undefined)
                {
                    await App.Current.MainPage.DisplayAlert("Ошибка", "Отсутствует подключение к интернету!", "Понятно");
                }
                if(ex.Reason == AuthErrorReason.InvalidEmailAddress)
                {
                    await App.Current.MainPage.DisplayAlert("Ошибка", "Введите корректный адрес почты!", "Понятно");
                }
                if(ex.Reason == AuthErrorReason.MissingPassword)
                {
                    await App.Current.MainPage.DisplayAlert("Ошибка", "Придумайте пароль!", "Понятно");
                }

            }
            catch(NullReferenceException)
            {

                await App.Current.MainPage.DisplayAlert("", $"Ошибка", "Понятно");
            }
        }

        private void UserName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(Regex.IsMatch(UserName.Text, "[^A-z-А-я]"))
            {
                UserName.Text = UserName.Text.Remove(UserName.Text.Length - 1);
                UserName.SelectionLength = UserName.Text.Length;
            }
        }
    }
}