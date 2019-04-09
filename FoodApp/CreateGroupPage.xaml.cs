using System;
using System.Collections.Generic;
using FoodApp.Model;
using FoodApp.Services;
using Xamarin.Forms;

namespace FoodApp
{
    public partial class CreateGroupPage : ContentPage
    {

        Group group;
        List<FoodUser> users;
        private bool IsJoining;

        public CreateGroupPage()
        {
            InitializeComponent();
            group = new Group();
            GroupCode.Text = group.GroupCode;
            users = new List<FoodUser>();

            Device.StartTimer(TimeSpan.FromSeconds(7), () =>
            {
                GetAllUsersInGroup();
                return true;
            });
            IsJoining = false;
        }

        public CreateGroupPage(bool isJoining, Group group)
        {
            InitializeComponent();
            users = new List<FoodUser>();

            GroupCode.IsVisible = !isJoining;
            this.group = group;
            Device.StartTimer(TimeSpan.FromSeconds(7), () =>
            {
                GetAllUsersInGroup();
                return true;
            });


            this.IsJoining = isJoining;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            if (!IsJoining)
            {
                await AzureService.InsertGroupAsync(group);
                await AzureService.JoinGroup(group, App.User);
            }
        }

        async void GetAllUsersInGroup()
        {
            List<FoodUser> userGroups = await AzureService.GetAllUsersInGroup(group);

            bool isFound;

            foreach (var item in userGroups)
            {
                isFound = false;
                foreach (var userItem in users)
                {
                    if (userItem.Id == item.Id)
                    {

                        isFound = true;
                    }
                }

                if (!isFound)
                {
                    Label label = new Label
                    {
                        Text = item.FirstName + " " + item.LastName
                    };

                    users.Add(item);

                    MainLayout.Children.Add(label);
                }

            }

        }

    }
}
