using System;
using System.Collections.Generic;
using FoodApp.Model;
using FoodApp.Services;
using Xamarin.Forms;

namespace FoodApp
{
    public partial class NavPage : ContentPage
    {


        public NavPage()
        {
            InitializeComponent();

            //googlePlacesService = new GooglePlacesService(40.235119, -111.662193);

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

        public void SearchBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SearchSettings());
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {

            //if (places == null)
            //{
            //    places = await googlePlacesService.GetPlaceList();
            //}
            //Random rnd = new Random();
            //int r = rnd.Next(places.Count);

            //Place place = places[r];

            //img.Source = ImageSource.FromUri(new Uri(place.GetPhotoURL()));
        }

        async void Handle_Clicked_1Async(object sender, System.EventArgs e)
        {
            //if (googlePlacesService.NextPageToken != string.Empty)
            //{
            //    places.Clear();
            //    var restaurents = await googlePlacesService.NextPageAsync();

            //    places.AddRange(restaurents);
            //}
        }

        async void PlacePage_Clicked(object sender, EventArgs e)
        {
            //googlePlacesService = new GooglePlacesService(40.235119, -111.662193);
            //if (places == null)
            //{
            //    places = await googlePlacesService.GetPlaceList();
            //}
            //Place place = places[1];
            //await Navigation.PushAsync(new PlacePage(place));

        }

        private void Swipe_Clicked(object sender, EventArgs e)
        {            
            Navigation.PushAsync(new Swipe());


        }
    }
}
