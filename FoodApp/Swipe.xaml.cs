using System;
using System.Collections.Generic;
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
        public Swipe()
        {
            InitializeComponent();

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

        async void OnSwiped(object sender, SwipedEventArgs e)
        {
            switch (e.Direction)
            {
                case SwipeDirection.Left:
                    await DisplayAlert("Question?", "Would you like to play a game", "Yes", "No");
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