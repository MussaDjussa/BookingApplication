using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookingApplication
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            BindingContext = App.StateViewModel;


            Routing.RegisterRoute(nameof(PreviewPage),
                typeof(PreviewPage));
            Routing.RegisterRoute(nameof(Page1),
               typeof(Page1));

            Routing.RegisterRoute(nameof(LoginPage),
                typeof(LoginPage));
            Routing.RegisterRoute(nameof(RegistrationPage),
                typeof(RegistrationPage));
            Routing.RegisterRoute(nameof(BookingPage),
                typeof(BookingPage));
            Routing.RegisterRoute(nameof(MainPage),
                typeof(MainPage));
            Routing.RegisterRoute(nameof(FeedbackTabbedPage),
                typeof(FeedbackTabbedPage));
            Routing.RegisterRoute(nameof(MyFeedbackPage),
                typeof(MyFeedbackPage));
            Routing.RegisterRoute(nameof(AdditionServiceTabbedPage),
                typeof(AdditionServiceTabbedPage));
        }
    }
}