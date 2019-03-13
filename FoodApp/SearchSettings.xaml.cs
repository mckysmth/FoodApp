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
  public partial class SearchSettings : ContentPage
  {
    public SearchSettings()
    {
      InitializeComponent();
    //  textLabel.Text = theSlider.Value.ToString();
    }

    private void SubmitBtn_Clicked(object sender, EventArgs e)
    {
      double distance = theSlider.Value; //???
    }
  }
}