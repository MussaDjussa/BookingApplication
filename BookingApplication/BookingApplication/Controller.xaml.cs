using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookingApplication
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Controller : ContentPage
    {
        public ObservableCollection<FoodModel> Collection = new ObservableCollection<FoodModel>();

        public Controller()
        {
            InitializeComponent();

            Collection.Add(new FoodModel()
            {

                Name = "controller",
                Price = "100 ₽",
                Image = "controller.png"
            });


            collection.ItemsSource = Collection;
            BindingContext = this;
        }
    }
}