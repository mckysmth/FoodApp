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
	public partial class RestaurantSearch : ContentPage
	{
		public RestaurantSearch ()
		{
			InitializeComponent ();
            FoodTypePicker.Items.Add("American Food");
            FoodTypePicker.Items.Add("Brazilian");
            FoodTypePicker.Items.Add("Chinese");
            FoodTypePicker.Items.Add("Peruvian");

        }

        private void FoodTypePicker_OnSelectedIndexChanged(object sender, EventArgs e)
        {
           var name =  FoodTypePicker.Items[FoodTypePicker.SelectedIndex];

            DisplayAlert(name, "Selected value", "OK");
        }

    }
}