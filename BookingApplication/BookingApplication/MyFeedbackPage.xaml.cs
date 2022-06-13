using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Syncfusion.SfSchedule.XForms;
using Xamarin.CommunityToolkit.Extensions;
namespace BookingApplication
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyFeedbackPage : ContentPage
    {
        public MyFeedbackPage()
        {
            InitializeComponent();
            collection.ItemsSource = App.viewModel.FeedbacksMyCollection;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.ShowPopup(new PopupFeedbackPage());
        }
    }
}