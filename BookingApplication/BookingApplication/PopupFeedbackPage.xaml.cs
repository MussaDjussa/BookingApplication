using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookingApplication
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupFeedbackPage : Popup, INotifyPropertyChanged
    {

        public PopupFeedbackPage()
        {
            InitializeComponent();
            
        }


        private void Button_Clicked(object sender, EventArgs e)
        {
            Dismiss(null);
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            FeedbackModel model = new FeedbackModel() {

                DateTime = DateTime.Now,
                FIO = FIO.Text,
                Description = Description.Text,
                FixedFromAdministration = Panishment.Text,

            };

            App.viewModel.FeedbacksMyCollection.Add(model);

            Dismiss(null);
        }
    }
}