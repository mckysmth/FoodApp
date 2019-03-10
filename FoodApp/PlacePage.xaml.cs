using FoodApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodApp.Model
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PlacePage : ContentPage

      
	{

        List<Place> places;
        GooglePlacesService googlePlacesService;


        public PlacePage()
		{
			InitializeComponent ();

            googlePlacesService = new GooglePlacesService(40.235119, -111.662193);
            getpicture();



        }

        async void getpicture()
        {

            if (places == null)
            {
                places = await googlePlacesService.GetPlaceList();
            }
            Random rnd = new Random();
            int r = rnd.Next(places.Count);

            Place place = places[r];

            PictureFrame.Source = ImageSource.FromUri(new Uri(place.GetPhotoURL()));
        }


    }
}