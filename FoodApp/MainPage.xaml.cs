using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodApp.Model;
using MongoDB.Driver;
using Xamarin.Forms;

namespace FoodApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
<<<<<<< HEAD
            var collection = Client.GetUserCollection(); 
=======
            Client.GetUserCollection().InsertOne(new User()); 
>>>>>>> 7b08b738530608b0aaafa5a09d5bb2010236c4a1
        }
    }
}
