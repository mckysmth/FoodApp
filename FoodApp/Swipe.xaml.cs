using FoodApp.Model;
using FoodApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodApp
{
    public partial class Swipe : ContentPage
    {
        ObservableCollection<Place> places;
        GooglePlacesService gps;
        double Latitude;
        double Longitude;
        public Swipe()
        {
            InitializeComponent();
            


            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += Tapped_handlerAsync;
            frame.GestureRecognizers.Add(tapGestureRecognizer);





        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Best);
                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    Latitude = location.Latitude;
                    Longitude = location.Longitude;
                    //Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
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
            gps = new GooglePlacesService(Latitude, Longitude);
            places = new ObservableCollection<Place>();

            InitPlaceList();

        }



        private void Tapped_handlerAsync(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PlacePage(places[0]));
        }

        private async void InitPlaceList()
        {
            foreach (var item in await gps.GetPlaceList())
            {
                places.Add(item);

            }
            TestLabel.Text = places[0].Name;
            TestImg.Source = ImageSource.FromUri(new Uri(places[0].GetPhotoURL()));


        }



        async void OnSwiped(object sender, SwipedEventArgs e)
        {
            switch (e.Direction)
            {
                case SwipeDirection.Left:
                    places.Remove(places[0]);
                    TestLabel.Text = places[0].Name;
                    TestImg.Source = ImageSource.FromUri(new Uri(places[0].GetPhotoURL()));
                    break;
                case SwipeDirection.Right:
                    var location = new Location(places[0].Latitude, places[0].Longitude);
                    var options = new MapLaunchOptions { Name = places[0].Name };

                    await Map.OpenAsync(location, options);
                    //Device.OpenUri(new Uri("https://www.google.com/maps/search/?api=1&query="
                    //+ places[0].Latitude 
                    //+"," 
                    //+ places[0].Longitude));
                    break;
                case SwipeDirection.Up:
                    // Handle the swipe
                    break;
                case SwipeDirection.Down:
                    // Handle the swipe
                    break;
                
            }
        }
    }
}