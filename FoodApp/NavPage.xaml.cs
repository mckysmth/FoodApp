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
            //Navigation.PushAsync(new MainPage());
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
