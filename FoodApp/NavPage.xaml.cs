using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FoodApp
{
    public partial class NavPage : ContentPage
    {
        public NavPage()
        {
            InitializeComponent();
        }

        void MainPageBtn_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
    }
}
