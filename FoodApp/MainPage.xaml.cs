using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodApp.Model;
using FoodApp.Services;
using Xamarin.Forms;

namespace FoodApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            TestMethod();
        }

        private async Task TestMethod()
        {
            MongoService mongoService = new MongoService();
            await mongoService.InsertNewUser(new User());
        }
    }
}
