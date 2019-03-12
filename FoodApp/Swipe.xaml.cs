using FoodApp.Model;
using FoodApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Swipe : ContentPage
    {
        ObservableCollection<Place> places;
        GooglePlacesService gps;
        public Swipe()
        {
            InitializeComponent();
            gps = new GooglePlacesService(40, -111);
            places = new ObservableCollection<Place>();
            InitPlaceList();
            //places = await gps.GetPlaceList();

            var boxView = new BoxView { Color = Color.Teal };
            var leftSwipeGesture = new SwipeGestureRecognizer { Direction = SwipeDirection.Left };
            leftSwipeGesture.Swiped += OnSwiped;
            var rightSwipeGesture = new SwipeGestureRecognizer { Direction = SwipeDirection.Right };
            rightSwipeGesture.Swiped += OnSwiped;
            var upSwipeGesture = new SwipeGestureRecognizer { Direction = SwipeDirection.Up };
            upSwipeGesture.Swiped += OnSwiped;
            var downSwipeGesture = new SwipeGestureRecognizer { Direction = SwipeDirection.Down };
            downSwipeGesture.Swiped += OnSwiped;

            boxView.GestureRecognizers.Add(leftSwipeGesture);
            boxView.GestureRecognizers.Add(rightSwipeGesture);
            boxView.GestureRecognizers.Add(upSwipeGesture);
            boxView.GestureRecognizers.Add(downSwipeGesture);

        }

        private async void InitPlaceList()
        {
            foreach (var item in await gps.GetPlaceList())
            {
                places.Add(item);

            }
            TestLabel.Text = places[0].Name;
            places.Remove(places[0]);

        }



        async void OnSwiped(object sender, SwipedEventArgs e)
        {
            switch (e.Direction)
            {
                case SwipeDirection.Left:
                    //await DisplayAlert("Question?", "Would you like to play a game", "Yes", "No");
                    TestLabel.Text = places[0].Name;
                    places.Remove(places[0]);
                    break;
                case SwipeDirection.Right:
                    await DisplayAlert("Question?", "Would you like to play a game heheheh", "Yes", "No");
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