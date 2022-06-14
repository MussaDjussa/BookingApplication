using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace BookingApplication
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Pin pin = new Pin()
            {
                Type = PinType.Place,
                Label = "Клуб приколов",
                Address = "Kazan",
                Position = new Position(55.78655751089976, 49.14419581205586),
                

            };
            map.Pins.Add(pin);
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}
