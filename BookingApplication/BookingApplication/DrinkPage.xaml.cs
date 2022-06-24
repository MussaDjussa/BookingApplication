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
    public partial class DrinkPage : ContentPage
    {
        public ObservableCollection<FoodModel> Collection = new ObservableCollection<FoodModel>();
        public DrinkPage()
        {
            InitializeComponent();

            Collection.Add(new FoodModel()
            {

                Name = "Sprite",
                Price = "99 ₽",
                Image = "sprite.png"
            });
            Collection.Add(new FoodModel()
            {

                Name = "cola zero",
                Price = "100 ₽",
                Image = "zero.png"
            });

            Collection.Add(new FoodModel()
            {

                Name = "fanta",
                Price = "80 ₽",
                Image = "fanta.png"
            });
            Collection.Add(new FoodModel()
            {

                Name = "monster",
                Price = "110 ₽",
                Image = "monster.png"
            });

            collection.ItemsSource = Collection;
            BindingContext = this;
        }
    }
}