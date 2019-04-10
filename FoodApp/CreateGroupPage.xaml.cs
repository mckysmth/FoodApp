using System;
using System.Collections.Generic;
using FoodApp.Model;
using FoodApp.Services;
using Xamarin.Essentials;
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
                GooglePlacesService placesService = null;

                App.User.IsPlaying = true;
                await AzureService.UpdateUser(App.User);

                List<Place> places = new List<Place>();
                try
                {
                    var request = new GeolocationRequest(GeolocationAccuracy.Best);
                    var location = await Geolocation.GetLocationAsync(request);


                    if (location != null)
                    {
                        placesService = new GooglePlacesService(location.Latitude, location.Longitude);
                    }
                }
                catch (FeatureNotSupportedException fnsEx)
                {
                    // Handle not supported on device exception
                }
                catch (FeatureNotEnabledException fneEx)
                {
                    // Handle not enabled on device exception
                }
                catch (PermissionException pEx)
                {
                    // Handle permission exception
                }
                catch (Exception ex)
                {
                    // Unable to get location
                }

                if (placesService != null)
                {
                    if (await placesService.GetPlaceList() is List<Place> googlePlaces)
                    {
                        places.AddRange(googlePlaces);
                    }

                    while (await placesService.NextPageAsync() is List<Place> googlePlacesList)
                    {
                        places.AddRange(googlePlacesList);
                    }
                }

                if (places.Count > 0)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        var rnd = new Random(DateTime.Now.Millisecond);
                        int ticks = rnd.Next(0, places.Count);

                        places[ticks].GroupID = group.Id;

                        await AzureService.InsertPlace(places[ticks]);

                        places.Remove(places[ticks]);
                    }
                }

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

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new Swipe(group));
        }
    }
}
