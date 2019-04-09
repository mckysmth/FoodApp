using System;
using System.Collections.Generic;
using FoodApp.Model;
using FoodApp.Services;
using Xamarin.Forms;

namespace FoodApp
{
    public partial class JoinGroupPage : ContentPage
    {
        public JoinGroupPage()
        {
            InitializeComponent();
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            Group group = await AzureService.GetGroup(GroupCode.Text);
            await AzureService.JoinGroup(group, App.User);
            await Navigation.PushAsync(new CreateGroupPage(true, group));
        }
    }
}
