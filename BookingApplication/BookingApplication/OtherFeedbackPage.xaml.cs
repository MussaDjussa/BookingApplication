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
    public partial class OtherFeedbackPage : ContentPage
    {
        public OtherFeedbackPage()
        {
            InitializeComponent();

            collection.ItemsSource = App.viewModel.FeedbacksMyCollection;
        }
    }
}