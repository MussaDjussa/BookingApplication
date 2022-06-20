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
    public partial class FoodPage : ContentPage
    {
        public ObservableCollection<FoodModel> Collection = new ObservableCollection<FoodModel>();
        public FoodPage()
        {
            InitializeComponent();

            Collection.Add(new FoodModel() {
           
                Name = "Шоколад",
                Price = "70",
                Image = "alpen1.jpg"
            });
            Collection.Add(new FoodModel() {
           
                Name = "Шоколад",
                Price = "70",
                Image = "alpen1.jpg"
            });
            Collection.Add(new FoodModel() {
           
                Name = "Шоколад",
                Price = "70",
                Image = "alpen1.jpg"
            });
            Collection.Add(new FoodModel() {
           
                Name = "Шоколад",
                Price = "70",
                Image = "alpen1.jpg"
            });
            //Collection.Add(new FoodModel() {
           
            //    Name = "Шоколад",
            //    Price = "70",
            //    Image = "alpen2.jpg"
            //});
            //Collection.Add(new FoodModel() {
           
            //    Name = "Шоколад",
            //    Price = "70",
            //    Image = "alpen3.jpg"
            //});
            //Collection.Add(new FoodModel() {
           
            //    Name = "Бургер",
            //    Price = "70",
            //    Image = "burger.jpg"
            //});
            //Collection.Add(new FoodModel() {
           
            //    Name = "Шоколад",
            //    Price = "70",
            //    Image = "milki.jpg"
            //});
            //Collection.Add(new FoodModel() {
           
            //    Name = "Наггетсы",
            //    Price = "70",
            //    Image = "nuggets.png"
            //});
            //Collection.Add(new FoodModel() {
           
            //    Name = "Наггетсы",
            //    Price = "70",
            //    Image = "potato.png"
            //});
            //Collection.Add(new FoodModel() {
           
            //    Name = "Наггетсы",
            //    Price = "70",
            //    Image = "sandwich.png"
            //});

            collection.ItemsSource = Collection;
            BindingContext = this;
        }
    }
}