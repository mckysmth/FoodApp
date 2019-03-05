using System;
using System.Collections.Generic;
using FoodApp.Services;
using Xamarin.Forms;

namespace FoodApp
{
    public partial class NavPage : ContentPage
    {
        public NavPage()
        {
            InitializeComponent();
            GooglePlacesService googlePlaces = new GooglePlacesService(40.758480, -111.888138);
        }

         void ProfilePageBtn_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ProfilePage());
        }

         void UserLoginBtn_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new Login());
        }

         void SignUpBtn_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new Signup());
        }
    }
}
